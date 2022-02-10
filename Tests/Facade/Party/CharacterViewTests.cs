using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party
{
    [TestClass] public class CharacterViewTests : BaseTests<CharacterView>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void HoqwartsHouseTest() => isProperty<string?>();
        [TestMethod] public void OrganisatsionTest() => isProperty<string?>();
    }
}
