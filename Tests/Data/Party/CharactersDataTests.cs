using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;

namespace Tests.Data.Party {
    [TestClass] public class CharactersDataTests : SealedClassTests<CharacterData> {
        [TestMethod] public void IDTest() => IsProperty<string?>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<bool?>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
        [TestMethod] public void HogwartsHouseTest() => IsProperty<string?>();
        [TestMethod] public void OrganisationTest() => IsProperty<string?>();
    }
}
