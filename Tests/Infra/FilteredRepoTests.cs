using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class FilteredRepoTests
        : AbstractClassTests<FilteredRepo<Character, CharacterData>, object> {
        protected override FilteredRepo<Character, CharacterData> CreateObj() {
            throw new NotImplementedException();
        }
    }
}
