using System.ComponentModel;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class WoodView : NamedView {
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
    public sealed class WoodViewFactory : BaseViewFactory<WoodView, Wood, WoodData> {
        protected override Wood ToEntity(WoodData d) => new(d);
        public override WoodView Create(Wood? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
