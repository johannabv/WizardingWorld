using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency ToEntity(CountryCurrencyData d) => new(d);
    }
    public sealed class CountryCurrencyView : NamedView {
        [DisplayName("Country"), Required] public string CountryID { get; set; } = string.Empty;
        [DisplayName("Currency"), Required] public string CurrencyID { get; set; } = string.Empty;
        [DisplayName("Currency native name"), Required] public new string? Name { get; set; } 
        [DisplayName("Currency native name"), Required] public new string? Code { get; set; }
    }
}
