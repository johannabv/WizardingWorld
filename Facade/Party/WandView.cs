using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class WandViewFactory : BaseViewFactory<WandView, Wand, WandData> {
        protected override Wand ToEntity(WandData d) => new(d);
        public override WandView Create(Wand? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class WandView : BaseView {
        [DisplayName("Core"), Required] public string? Core { get; set; }
        [DisplayName("Wood"), Required] public string? Wood { get; set; }
        [DisplayName("Info about core")] public string? CoreInfo { get; set; }
        [DisplayName("Info about wood")] public string? WoodInfo { get; set; }
        [DisplayName("Info")] public string? Info { get; set; }
        [DisplayName("Full Wand Info")] public string? FullName { get; set; }
    }
}
