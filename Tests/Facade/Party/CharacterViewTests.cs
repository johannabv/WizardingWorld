using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Data.Enums;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewTests : SealedClassTests<CharacterView, BaseView> {
        [TestMethod] public void IDTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<IsoGender>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
        [TestMethod] public void HogwartsHouseTest() => IsProperty<string?>();
        [TestMethod] public void OrganisationTest() => IsProperty<Side?>();
    }
}
