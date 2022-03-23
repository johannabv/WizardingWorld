using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency ToEntity(CurrencyData d) => new(d);
        public override CurrencyView Create(Currency? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class CurrencyView : BaseView {
        [DisplayName("Country's name"), Required] public string? Name { get; set; }
        [DisplayName("Code"), Required] public string? Code { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
