using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WizardingWorld.Aids;
using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>, IPageModel, IIndexModel<TView>
        where TView : BaseView, new()
        where TEntity : BaseEntity
        where TRepo : IPagedRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        protected override void SetAttributes(int pageIndex, string? currentFilter, string? sortOrder) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            CurrentOrder = sortOrder;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage  => repo.HasNextPage;
        public bool HasPreviousPage  => repo.HasPreviousPage; 
        public virtual string[] IndexColumns => Array.Empty<string>();
        public virtual string[] IndexColumnsRelatedTable => Array.Empty<string>();
        protected override IActionResult RedirectToIndex() => RedirectToPage("./Index", "Index", new {
            pageIndex = PageIndex,
            currentFilter = CurrentFilter,
            sortOrder = CurrentOrder} 
        );
        public virtual object? GetValue(string name, TView v)
            => Safe.Run(() => {
                var pi = v?.GetType()?.GetProperty(name);
                return pi?.GetValue(v);
            }, null); 
        public string? DisplayName(string name) => Safe.Run(() => {
            var p = typeof(TView).GetProperty(name);
            var a = p?.CustomAttributes?
                .FirstOrDefault(x => x.AttributeType == typeof(DisplayNameAttribute));
            return a?.ConstructorArguments[0].Value?.ToString() ?? name;
        }, name);
    }
}
