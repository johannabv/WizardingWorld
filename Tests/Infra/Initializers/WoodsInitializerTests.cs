﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class WoodsInitializerTests
        : SealedBaseTests<WoodsInitializer, BaseInitializer<WoodData>> {
        protected override WoodsInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new WoodsInitializer(db);
        }
    }
}
