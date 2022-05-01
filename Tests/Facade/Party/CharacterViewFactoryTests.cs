﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewFactoryTests 
        : ViewFactoryTests<CharacterViewFactory, CharacterView, Character, CharacterData> {
        protected override Character ToObject(CharacterData d) => new(d);
    }
}
