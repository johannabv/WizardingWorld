using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : IBaseRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { } 
        public string? CurrentSort { get; set; }
        public string? CurrentFilter { get; set; }
        public int PageIndex { get; set; }
        public int PagesCount { get; set; }
    }
}
