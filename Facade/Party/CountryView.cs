using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country ToEntity(CountryData d) => new(d); 
    }
    public sealed class CountryView : BaseView {
        [DisplayName("Country's name"), Required] public string? EnglishName { get; set; }
        [DisplayName("Code"), Required] public string? Code { get; set; }
        [DisplayName("Native name"), Required] public string? NativeName { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
