using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, BaseEntity<CountryData>> {
        private class TestClass : NamedEntity<CountryData> { }
        protected override NamedEntity<CountryData> CreateObj() => new TestClass();
        [TestMethod] public void NameTest() => IsInconclusive();
        [TestMethod] public void CodeTest() => IsInconclusive();
        [TestMethod] public void DescriptionTest() => IsInconclusive();
    }
}
