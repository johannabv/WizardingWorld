﻿using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency ToEntity(CurrencyData d) => new(d); 
    }
    public sealed class CurrencyView : NamedView { }
}
