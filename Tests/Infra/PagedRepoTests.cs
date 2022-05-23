using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Character, CharacterData>, OrderedRepo<Character, CharacterData>> {
        private class TestClass : PagedRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override PagedRepo<Character, CharacterData> CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            DbSet<CharacterData>? set = db?.Characters;
            IsNotNull(set);
            return new TestClass(db, set);
        }
        [TestMethod] public void PageIndexTest() => IsProperty<int>();
        [TestMethod] public void HasPreviousPageTest() => IsReadOnly<bool?>();
        [TestMethod] public void PageSizeTest() => IsProperty<int>();
        [TestMethod] public void TotalPagesTest() => IsReadOnly<int>();
        [TestMethod] public void CountPagesTest() => IsReadOnly<double>();
        [TestMethod] public void ItemsCountTest() => IsReadOnly<int>();
        [TestMethod] public void totalPagesTest() => IsReadOnly<int>();
        [TestMethod] public void HasNextPageTest() => IsReadOnly<bool>();
    }
}
