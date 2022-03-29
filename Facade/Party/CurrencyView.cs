using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency ToEntity(CurrencyData d) => new(d); 
    }
    public sealed class CurrencyView : BaseView {
        [DisplayName("Currency's name"), Required] public string? Name { get; set; }
        [DisplayName("Code"), Required] public string? Code { get; set; }
        [DisplayName("Native name"), Required] public string? Description { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
