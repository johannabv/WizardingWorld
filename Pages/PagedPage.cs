using Microsoft.AspNetCore.Mvc;
using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : IPagedRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { }
        public string? CurrentSort { get; set; }
        public string? CurrentFilter {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage  => repo.HasNextPage;
        public bool HasPreviousPage  => repo.HasPreviousPage;
        public override IActionResult OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return base.OnGetCreate(pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            ModelState.Remove(nameof(currentFilter));
            ModelState.Remove(nameof(sortOrder));
            return await base.OnPostCreateAsync(pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetDetailsAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetDeleteAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnPostDeleteAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetEditAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            ModelState.Remove(nameof(currentFilter));
            ModelState.Remove(nameof(sortOrder));
            return await base.OnPostEditAsync(pageIndex, currentFilter ?? string.Empty, sortOrder ?? string.Empty);
        }
        public async override Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {  
            PageIndex=pageIndex;
            CurrentFilter=currentFilter;
            return await base.OnGetIndexAsync(pageIndex, currentFilter, sortOrder);
        }
    }
}
