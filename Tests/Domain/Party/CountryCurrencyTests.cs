﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
        protected override CountryCurrency CreateObj() => new(GetRandom.Value<CountryCurrencyData>());
        [TestMethod] public void CurrencyIDTest() => IsReadOnly(obj.Data.CurrencyID);
        [TestMethod] public void CountryIDTest() => IsReadOnly(obj.Data.CountryID);
        [TestMethod] public void CountryTest() => IsInconclusive();
        [TestMethod] public void CurrencyTest() => IsInconclusive();
    }
}
