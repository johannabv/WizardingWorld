using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity<CountryData>, BaseEntity> {
        private class TestClass : BaseEntity<CountryData> { }
        protected override BaseEntity<CountryData> CreateObj() => new TestClass();
        [TestMethod] public void IdTest() => IsInconclusive();
        [TestMethod] public void DefaultStrTest() => IsInconclusive();
        [TestMethod] public void DefaultDateTest() => IsInconclusive();
    }
}
