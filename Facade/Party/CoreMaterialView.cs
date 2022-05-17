using System.ComponentModel;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;

namespace WizardingWorld.Facade.Party {
    public sealed class CoreMaterialView : NamedView {
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
    public sealed class CoreViewFactory : BaseViewFactory<CoreMaterialView, CoreMaterial, CoreMaterialData> {
        protected override CoreMaterial ToEntity(CoreMaterialData d) => new(d);
        public override CoreMaterialView Create(CoreMaterial? e) {
            CoreMaterialView v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}


