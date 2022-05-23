﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain {
    [TestClass] public abstract class GetRepoTests : global::Tests.TypeTests {
        private class TestClass : IServiceProvider {
            public object? GetService(Type serviceType) {
                throw new NotImplementedException();
            }
        }
        [TestMethod] public void InstanceTest() => Assert.IsInstanceOfType(GetRepo.Instance<ICountriesRepo>(), typeof(CountriesRepo));
        [TestMethod] public void SetServiceTest() {
            IServiceProvider? s = GetRepo.service;
            TestClass x = new();
            GetRepo.SetService(x);
            AreEqual(x,GetRepo.service);
            GetRepo.service = s;
        }
    }
}
