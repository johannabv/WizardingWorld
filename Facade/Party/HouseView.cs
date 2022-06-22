using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class HouseViewFactory : BaseViewFactory<HouseView, House, HouseData> {
        protected override House ToEntity(HouseData d) => new(d);
        public override HouseView Create(House? e) {
            HouseView v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class HouseView : BaseView {
        [DisplayName("House name"), Required] public string? HouseName { get; set; }
        [DisplayName("Founder name")] public string? FounderName { get; set; }
        [DisplayName("Head of House name")] public string? HeadOfHouseName { get; set; }
        [DisplayName("Color"), Required] public string? Color { get; set; }
        [DisplayName("GetDescription")] public string? Description { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
