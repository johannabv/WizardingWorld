﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class GetNamespaceTests : TypeTests {
        [TestMethod] public void OfTypeTest() {
            var obj = new CountryData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            AreEqual(name, n);
        }
        [TestMethod] public void OfTypeNullTest() {
            CountryData? obj = null;
            var n = GetNamespace.OfType(obj);
            AreEqual(string.Empty, n);
        }
    }
}
