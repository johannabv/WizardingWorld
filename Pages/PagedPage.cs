using Microsoft.AspNetCore.Mvc;
using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : IPagedRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public string? SortOrder(string propertyName) => repo.SortOrder(propertyName); 
        protected override void SetAttributes(int pageIndex, string? currentFilter, string? sortOrder) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            CurrentSort = sortOrder;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage  => repo.HasNextPage;
        public bool HasPreviousPage  => repo.HasPreviousPage; 
        protected override IActionResult RedirectToIndex() {
            return RedirectToPage("./Index", "Index", new {
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentSort
            }
            ) ;
        }
    }
}
