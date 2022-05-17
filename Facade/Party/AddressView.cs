using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData> {
        protected override Address ToEntity(AddressData d) => new(d);
        public override AddressView Create(Address? e) {
            AddressView v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class AddressView : BaseView {
        [Required] [DisplayName("Street")] public string? Street { get; set; }
        [DisplayName("City")] public string? City { get; set; }
        [DisplayName("Region")] public string? Region { get; set; }
        [DisplayName("Zip code")] public string? ZipCode { get; set; }
        [DisplayName("Country")] public string? CountryID { get; set; }
        [Required] [DisplayName("Description")] public string? Description { get; set; } 
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
