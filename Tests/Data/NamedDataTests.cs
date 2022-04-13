﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;

namespace WizardingWorld.Tests.Data {
    [TestClass] public class NamedDataTests : AbstractClassTests {
        private class TestClass : NamedData { }
        protected override object CreateObj() => new TestClass();
        [TestMethod] public void CodeTest() => IsProperty<string>();
        [TestMethod] public void NameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
