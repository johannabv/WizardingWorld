using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;

namespace WizardingWorld.Facade.Party {
    public sealed class CoreView : NamedView { }
    public sealed class CoreViewFactory : BaseViewFactory<CoreView, Core, CoreData> {
        protected override Core ToEntity(CoreData d) => new(d);
    }
}


