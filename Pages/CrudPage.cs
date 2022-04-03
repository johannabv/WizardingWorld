using Microsoft.AspNetCore.Mvc;
using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : ICrudRepo<TEntity> {
        protected CrudPage(TRepo r) : base(r) { }
        protected override IActionResult GetCreate() => Page();
        public string ItemId => Item?.ID ?? string.Empty;
        protected override async Task<IActionResult> PostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(ToObject(Item));
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> GetDetailsAsync(string id) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> GetDeleteAsync(string id) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> PostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> GetEditAsync(string id) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> PostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = ToObject(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToIndex();
        }
        protected override async Task<IActionResult> GetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (var obj in list) Items.Add(ToView(obj));
            return Page();
        }
        private async Task<TView> GetItem(string id) => ToView(await repo.GetAsync(id));
    }
}
