﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class HousesInitializerTests
        : SealedBaseTests<HousesInitializer, BaseInitializer<HouseData>> {
        protected override HousesInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new HousesInitializer(db);
        }
    }
}
