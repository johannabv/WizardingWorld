using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class WoodViewFactory : BaseViewFactory<WoodView, Wood, WoodData> {
        protected override Wood ToEntity(WoodData d) => new(d);
    }
    public sealed class WoodView : NamedView { }
}
