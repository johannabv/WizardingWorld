﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class RepoTests : AbstractClassTests<Repo<Character, CharacterData>, PagedRepo<Character, CharacterData>> {
        private class TestClass : Repo<Character, CharacterData> {
            public TestClass(DbContext? context, DbSet<CharacterData>? set) : base(context, set) { } 
            protected internal override Character ToDomain(CharacterData d)=> new(d);
        }
        protected override Repo<Character, CharacterData> CreateObj() => new TestClass(null,null);
    }
}
