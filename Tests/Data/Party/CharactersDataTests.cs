using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;

namespace Tests.Data.Party {
    [TestClass] public class CharactersDataTests : BaseTests<CharacterData> {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void HogwartsHouseTest() => isProperty<string?>();
        [TestMethod] public void OrganisationTest() => isProperty<string?>();
    }
}
