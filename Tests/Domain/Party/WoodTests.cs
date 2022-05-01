﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WoodTests : SealedClassTests<Wood, NamedEntity<WoodData>> {
        protected override Wood CreateObj() => new(GetRandom.Value<WoodData>());
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.Name}: {obj.Description}";
            AreEqual(expected, obj.ToString());
        }
    }
}
