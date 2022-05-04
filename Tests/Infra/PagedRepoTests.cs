using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Character, CharacterData>, object> {
        protected override PagedRepo<Character, CharacterData> CreateObj() {
            throw new NotImplementedException();
        }
    }
}
