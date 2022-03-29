using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : BaseEntity
        where TRepo : ICrudRepo<TEntity> {
        protected CrudPage(TRepo r) : base(r) { }
    }
}
