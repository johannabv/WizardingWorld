using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace Tests.Infra { 
    [TestClass] public class RepoTests : AbstractClassTests {
        private class TestClass : Repo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { } 
            protected override Character ToDomain(CharacterData d)=> new(d);
        }
        protected override object createObj() => new TestClass(null,null);
    }  
}
