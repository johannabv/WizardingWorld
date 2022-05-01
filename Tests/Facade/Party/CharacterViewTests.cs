using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Data.Enums;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewTests : SealedClassTests<CharacterView, BaseView> {
        [TestMethod] public void FirstNameTest() => IsDisplayNamed<string?>("First name");
        [TestMethod] public void LastNameTest() => IsRequired<string?>("Last name");
        [TestMethod] public void GenderTest() => IsRequired<IsoGender>("Gender");
        [TestMethod] public void DoBTest() => IsDisplayNamed<DateTime?>("Date of Birth");
        [TestMethod] public void HogwartsHouseTest() => IsDisplayNamed<string?>("Hogwartz House");
        [TestMethod] public void OrganisationTest() => IsDisplayNamed<Side?>("Organisation");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }
}
