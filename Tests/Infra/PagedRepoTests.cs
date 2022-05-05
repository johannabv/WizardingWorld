using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Character, CharacterData>, OrderedRepo<Character, CharacterData>> {
        private class TestClass : PagedRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override PagedRepo<Character, CharacterData> CreateObj() => new TestClass(null, null);

    }
}
