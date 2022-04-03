using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WizardingWorld.Aids;
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
        protected abstract IActionResult RedirectToIndex();
        [BindProperty] public TView? Item { get; set; }
        public IList<TView>? Items { get; set; }
        public BasePage(TRepo r) => repo = r;
        protected abstract void SetAttributes(int index, string? filter, string? order);
        protected abstract IActionResult GetCreate();
        protected abstract Task<IActionResult> GetIndexAsync(); 
        protected abstract Task<IActionResult> PostCreateAsync();
        protected abstract Task<IActionResult> GetDetailsAsync(string id);
        protected abstract Task<IActionResult> GetDeleteAsync(string id);
        protected abstract Task<IActionResult> PostDeleteAsync(string id);
        protected abstract Task<IActionResult> GetEditAsync(string id);
        protected abstract Task<IActionResult> PostEditAsync();
        protected async virtual Task<IActionResult> Perform(Func<Task<IActionResult>>f, int index, string? filter, string? order, bool removeKeys = false) {
            SetAttributes(index, filter, order);
            if(removeKeys) RemoveKey(nameof(filter), nameof(order));
            return await f();
        }
        internal virtual void RemoveKey(params string[] keys) {
            foreach(var key in keys ?? Array.Empty<string>()) Safe.Run(() => ModelState.Remove(key));
        }
        public IActionResult OnGetCreate(int index = 0, string? filter = null, string? order = null) {
            SetAttributes(index, filter, order);
            return GetCreate();
        }
        public async Task<IActionResult> OnPostCreateAsync(int index = 0, string? filter = null, string? order = null) 
            => await Perform(() => PostCreateAsync(), index, filter, order, true); 
        public async Task<IActionResult> OnGetDetailsAsync(string id, int index = 0, string? filter = null, string? order = null)
            => await Perform(() => GetDetailsAsync(id), index, filter, order);
        public async Task<IActionResult> OnGetDeleteAsync(string id, int index = 0, string? filter = null, string? order = null)
            => await Perform(() => GetDeleteAsync(id), index, filter, order);
        public async Task<IActionResult> OnPostDeleteAsync(string id, int index = 0, string? filter = null, string? order = null)
            => await Perform(() => PostDeleteAsync(id), index, filter, order);
        public async Task<IActionResult> OnGetEditAsync(string id, int index = 0, string? filter = null, string? order = null)
            => await Perform(() => GetEditAsync(id), index, filter, order);
        public async Task<IActionResult> OnPostEditAsync(int index = 0, string? filter = null, string? order = null)
            => await Perform(() => PostEditAsync(), index, filter, order, true);
        public async Task<IActionResult> OnGetIndexAsync(int index = 0, string? filter = null, string? order = null)
            => await Perform(() => GetIndexAsync(), index, filter, order);
    }
}
