using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewTests : SealedClassTests<CharacterView> {
        [TestMethod] public void IDTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<bool?>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
        [TestMethod] public void HogwartsHouseTest() => IsProperty<string?>();
        [TestMethod] public void OrganisationTest() => IsProperty<string?>();
    }
}
