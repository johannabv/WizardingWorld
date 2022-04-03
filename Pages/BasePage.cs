using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class BasePage<TView, TEntity, TRepo> : PageModel 
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : IBaseRepo<TEntity>{
        protected readonly TRepo repo;
        protected abstract TEntity ToObject(TView? item);
        protected abstract TView ToView(TEntity? entity);
        [BindProperty] public TView? Item { get; set; }
        public IList<TView>? Items { get; set; }
        public BasePage(TRepo r) => repo = r;
        public virtual IActionResult OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) => Page();
        public string ItemId => Item?.ID ?? string.Empty;
        public virtual async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(ToObject(Item));
            return RedirectToPage("./Index", "Index", new {
                pageIndex = pageIndex,
                currentFilter = currentFilter,
                sortOrder = sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index", new {
                pageIndex = pageIndex,
                currentFilter = currentFilter,
                sortOrder = sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await GetItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (!ModelState.IsValid) return Page();
            var obj = ToObject(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index", new {
                pageIndex = pageIndex,
                currentFilter = currentFilter,
                sortOrder = sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (var obj in list) { 
                Items.Add(ToView(obj));
            }
            return Page();
        }
        private async Task<TView> GetItem(string id) => ToView(await repo.GetAsync(id)); 
    }
}
