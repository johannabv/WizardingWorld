using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class BaseEntityTests : AbstractClassTests {
        private class TestClass : BaseEntity<CountryData> { }
        protected override object CreateObj() => new TestClass();
        [TestMethod] public void DefaultStrTest() => IsInconclusive();
        [TestMethod] public void DefaultDateTest() => IsInconclusive();
        [TestMethod] public void GetValueTest() => IsInconclusive();
    }
}
