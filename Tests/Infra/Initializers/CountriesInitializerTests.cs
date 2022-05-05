﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class CountriesInitializerTests
        : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>> {
        protected override CountriesInitializer CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            return new CountriesInitializer(db);
        }
    }
}