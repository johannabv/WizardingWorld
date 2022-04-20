using System.ComponentModel;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;

namespace WizardingWorld.Facade.Party {
    public sealed class CoreView : NamedView {
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
    public sealed class CoreViewFactory : BaseViewFactory<CoreView, Core, CoreData> {
        protected override Core ToEntity(CoreData d) => new(d);
        public override CoreView Create(Core? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}


