using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass] public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, BaseEntity<CountryData>> {
        private class TestClass : NamedEntity<CountryData> {
            public TestClass() : this(new CountryData()) { }
            public TestClass(CountryData d) : base(d) { }
        }
        protected override NamedEntity<CountryData> CreateObj() => new TestClass(GetRandom.Value<CountryData>());
        [TestMethod] public void NameTest() => IsReadOnly(Obj.Data.Name);
        [TestMethod] public void CodeTest() => IsReadOnly(Obj.Data.Code);
        [TestMethod] public void DescriptionTest() => IsReadOnly(Obj.Data.Description);
    }
}
