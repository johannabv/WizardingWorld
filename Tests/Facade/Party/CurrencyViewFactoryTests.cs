﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CurrencyViewFactoryTests
        : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData> {
        protected override Currency ToObject(CurrencyData d) => new(d);
    }
}
