using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class BaseEntityTests : AbstractClassTests {
        private class TestClass : BaseEntity<CountryData> { }
        protected override object CreateObj() => new TestClass();
    }
}
