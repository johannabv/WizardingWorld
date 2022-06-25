using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class GetNamespaceTests : TypeTests {
        [TestMethod] public void OfTypeTest() {
            CountryData obj = new();
            string? expectedName = obj.GetType().Namespace;
            string? actualName = GetNamespace.OfType(obj);
            AreEqual(expectedName, actualName);
        }
        [TestMethod] public void OfTypeNullTest() {
            CountryData? obj = null;
            string? actualName = GetNamespace.OfType(obj);
            AreEqual(string.Empty, actualName);
        }
    }
}
