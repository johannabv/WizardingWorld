using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class FilteredRepoTests
        : AbstractClassTests<FilteredRepo<Character, CharacterData>, CrudRepo<Character, CharacterData>> {
        private class TestClass : FilteredRepo<Character, CharacterData> {
            public TestClass(DbContext? context, DbSet<CharacterData>? set) : base(context, set) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override FilteredRepo<Character, CharacterData> CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            DbSet<CharacterData>? set = db?.Characters;
            return new TestClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => IsProperty<string>();
        
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSqlTest(bool hasCurrentFilter) {
            Obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            IQueryable<CharacterData> q1 = Obj.CreateSql();
            IQueryable<CharacterData> q2 = Obj.AddFilter(q1);
            AreEqual(q1, q2);
            string s = q1.Expression.ToString();
            IsTrue(s.EndsWith(".Select(set => set)"));
        }
    }
}
