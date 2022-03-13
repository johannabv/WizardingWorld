using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace Tests.Infra { 
    [TestClass] public class RepoTests : AbstractClassTests {
        private class TestClass : Repo<Spell, SpellData> {
            public TestClass(DbContext? c, DbSet<SpellData>? s) : base(c, s) { } 
            protected override Spell ToDomain(SpellData d)=> new(d);
        }
        protected override object CreateObject() => new TestClass(null,null);
    }  
}
