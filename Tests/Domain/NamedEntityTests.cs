using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class NamedEntityTests : AbstractClassTests {
        private class TestClass : NamedEntity<CountryData> { }
        protected override object CreateObj() => new TestClass();
    }
}
