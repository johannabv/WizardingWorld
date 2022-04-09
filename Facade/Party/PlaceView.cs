using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class PlaceViewFactory : BaseViewFactory<PlaceView, Place, PlaceData> {
        protected override Place ToEntity(PlaceData d) => new(d);
        public override PlaceView Create(Place? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class PlaceView : BaseView {
        [Required] [DisplayName("Street")] public string? Street { get; set; }
        [DisplayName("City")] public string? City { get; set; }
        [DisplayName("Region")] public string? Region { get; set; }
        [DisplayName("Zip code")] public string? ZipCode { get; set; }
        [DisplayName("Country")] public string? CountryId { get; set; }
        [Required] [DisplayName("Description")] public string? Description { get; set; } 
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
