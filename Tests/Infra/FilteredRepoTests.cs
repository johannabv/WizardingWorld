using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class FilteredRepoTests
        : AbstractClassTests<FilteredRepo<Character, CharacterData>, CrudRepo<Character, CharacterData>> {
        private class TestClass : FilteredRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override FilteredRepo<Character, CharacterData> CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            var set = db?.Characters;
            return new TestClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => IsProperty<string>();
        
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSQLTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.CreateSQL();
            var q2 = obj.AddFilter(q1);
            AreEqual(q1, q2);
            var s = q1.Expression.ToString();
            IsTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}
