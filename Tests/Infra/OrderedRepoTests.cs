using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class OrderedRepoTests
        : AbstractClassTests<OrderedRepo<Character, CharacterData>, FilteredRepo<Character,CharacterData>> {
        private class TestClass : OrderedRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override OrderedRepo<Character, CharacterData> CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            DbSet<CharacterData>? set = db?.Characters;
            return new TestClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => IsProperty<string>();
        [TestMethod] public void DescendingStringTest() => AreEqual("_desc", TestClass.DescendingString);
        
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Character.ID), true)]
        [DataRow(nameof(Character.ID), false)]
        [DataRow(nameof(Character.FirstName), true)]
        [DataRow(nameof(Character.FirstName), false)]
        [DataRow(nameof(Character.LastName), true)]
        [DataRow(nameof(Character.LastName), false)]
        [DataRow(nameof(Character.Gender), true)]
        [DataRow(nameof(Character.Gender), false)]
        [DataRow(nameof(Character.DoB), true)]
        [DataRow(nameof(Character.DoB), false)]
        [DataRow(nameof(Character.Organisation), true)]
        [DataRow(nameof(Character.Organisation), false)]
        [DataRow(nameof(Character.HogwartsHouse), true)]
        [DataRow(nameof(Character.HogwartsHouse), false)]
        [TestMethod] public void CreateSQLTest(string str, bool isDescending) {
            obj.CurrentOrder = (str is null) ? str : isDescending ? str + TestClass.DescendingString : str;
            IQueryable<CharacterData> q = obj.CreateSQL();
            string? actual = q.Expression.ToString();
            if (str is null) IsTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) IsTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{str}, Object))"));
            else IsTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{str}, Object))"));
        }
        
        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false,false)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) { 
            string s = GetRandom.String();
            string c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + TestClass.DescendingString : c;
            string actual = obj.SortOrder(s);
            string sDes = s + TestClass.DescendingString;
            string expected = isSame ? (isDescending ? s : sDes) : sDes;
            AreEqual(expected, actual);
        }
    }
}
