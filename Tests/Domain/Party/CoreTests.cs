using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CoreTests : SealedClassTests<Core, NamedEntity<CoreData>> {
        protected override Core CreateObj() => new(GetRandom.Value<CoreData>());
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.Name}: {obj.Description}";
            AreEqual(expected, obj.ToString());
        }
    }
}
