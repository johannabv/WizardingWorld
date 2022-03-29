using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : IFilteredRepo<TEntity> {
        protected FilteredPage(TRepo r) : base(r) { }
    }
}
