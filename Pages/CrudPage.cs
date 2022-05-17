using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WizardingWorld.Aids;
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
            string? s = TempData["Item"] as string;
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
            foreach (PropertyInfo p in Item.GetType().GetProperties()) {
                string n = p.Name;
                string? currentValue = p.GetValue(Item)?.ToString();
                string? clientValue = v?.GetType()?.GetProperty(n)?.GetValue(v)?.ToString();
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
            TView o = await GetItem(id);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) return RedirectToIndex();
            string oToken = ConcurrencyToken.ToStr(o.Token);
            if (oToken != token) return RedirectToDelete(id);

            _ = await repo.DeleteAsync(id);
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> PostEditAsync() {
            TEntity o = repo.Get(Item.ID);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) {
                ModelState.AddModelError(string.Empty, "Unable to save. The item was deleted by another user.");
                return Page();
            }
            string oToken = ConcurrencyToken.ToStr(o.Token);
            string itemToken = ConcurrencyToken.ToStr(Item.Token);
            if (oToken != itemToken) return RedirectToEdit(Item);

            if (!ModelState.IsValid) return Page();
            TEntity obj = ToObject(Item);
            bool updated = await repo.UpdateAsync(obj);
            return !updated ? NotFound() : RedirectToIndex();
        }
        protected override async Task<IActionResult> GetIndexAsync() {
            List<TEntity> list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (TEntity obj in list) {
                TView v = ToView(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<TView> GetItem(string id)
            => ToView(await repo.GetAsync(id));
    }
}
