﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;

namespace Tests.Facade.Party {
    [TestClass]
    public class BaseViewTests : AbstractClassTests {
        private class TestClass : BaseView { }
        protected override object CreateObj() => new TestClass(); 
    }
}
