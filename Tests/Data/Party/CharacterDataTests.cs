using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Data;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class CharacterDataTests : SealedClassTests<CharacterData, BaseData> {
        [TestMethod] public void IdTest() => IsProperty<string?>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<IsoGender?>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
        [TestMethod] public void HogwartsHouseTest() => IsProperty<string?>();
        [TestMethod] public void OrganizationTest() => IsProperty<Side?>();
    }
}
