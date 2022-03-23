using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class CurrenciesPage : BasePage<CurrencyView, Currency, ICurrencyRepo> {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency ToObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView ToView(Currency? entity) => new CurrencyViewFactory().Create(entity);
    }
}
