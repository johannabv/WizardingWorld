using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WizardingWorld.Core;
using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : BaseView, new() 
        where TEntity : BaseEntity
        where TRepo : ICrudRepo<TEntity> {
        protected CrudPage(TRepo r) : base(r) { }
        protected override IActionResult GetCreate() => Page();
        protected IActionResult ItemPage() => Item == null ? NotFound() : Page();
        protected virtual async Task<IActionResult> GetItemPage(string id) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> GetDetailsAsync(string id) => await GetItemPage(id);
        protected override async Task<IActionResult> GetDeleteAsync(string id) {
            ErrorMessage = TempData["Error"] as string;
            return await GetItemPage(id);
        }
        protected override async Task<IActionResult> GetEditAsync(string id) {
            var s = TempData["Item"] as string;
            TView? v = null;
            if (s is not null) v = JsonSerializer.Deserialize<TView>(s);
            if (v is null) return await GetItemPage(id);
            return await GetEditAsync(v);
        }
        protected async Task<IActionResult> GetEditAsync(TView v) {
            Item = await GetItem(v.ID);
            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit was modified by another user after you. The "
                + "edit operation was canceled and the current values in the database "
                + "have been displayed. If you still want to edit this record, click "
                + "the Save button again.");
            foreach (var p in Item.GetType().GetProperties()) {
                var n = p.Name;
                var currentValue = p.GetValue(Item)?.ToString();
                var clientValue = v?.GetType()?.GetProperty(n)?.GetValue(v)?.ToString();
                if (currentValue != clientValue)
                    ModelState.AddModelError(
                        $"{nameof(Item)}.{n}",
                        $"Your value: {clientValue}");
            }
            return ItemPage();
        }
        protected override async Task<IActionResult> PostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            _ = await repo.AddAsync(ToObject(Item));
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> PostDeleteAsync(string id, string? token = null) {
            if (id == null) return RedirectToIndex();
            var o = await GetItem(id);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) return RedirectToIndex();
            var oToken = ConcurrencyToken.ToStr(o.Token);
            if (oToken != token) return RedirectToDelete(id);

            _ = await repo.DeleteAsync(id);
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> PostEditAsync() {
            var o = repo.Get(Item.ID);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) {
                ModelState.AddModelError(string.Empty, "Unable to save. The item was deleted by another user.");
                return Page();
            }
            var oToken = ConcurrencyToken.ToStr(o.Token);
            var itemToken = ConcurrencyToken.ToStr(Item.Token);
            if (oToken != itemToken) return RedirectToEdit(Item);

            if (!ModelState.IsValid) return Page();
            var obj = ToObject(Item);
            var updated = await repo.UpdateAsync(obj);
            return !updated ? NotFound() : RedirectToIndex();
        }
        protected override async Task<IActionResult> GetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (var obj in list) {
                var v = ToView(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<TView> GetItem(string id)
            => ToView(await repo.GetAsync(id));
    }
}
