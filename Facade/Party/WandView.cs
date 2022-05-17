using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class WandViewFactory : BaseViewFactory<WandView, Wand, WandData> {
        protected override Wand ToEntity(WandData d) => new(d);
        public override WandView Create(Wand? e) {
            WandView v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class WandView : BaseView {
        [DisplayName("Core"), Required] public string? CoreID { get; set; }
        [DisplayName("Wood"), Required] public string? WoodID { get; set; }
        [DisplayName("Info")] public string? Info { get; set; }
        [DisplayName("Full Wand Info")] public string? FullName { get; set; }
    }
}
