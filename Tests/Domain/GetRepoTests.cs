using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain {
    [TestClass] public class GetRepoTests : global::Tests.TypeTests {
        private class testClass : IServiceProvider {
            public object? GetService(Type serviceType) {
                throw new NotImplementedException();
            }
        }
        [TestMethod] public void InstanceTest() => Assert.IsInstanceOfType(GetRepo.Instance<ICountriesRepo>(), typeof(CountriesRepo));
        [TestMethod] public void SetServiceTest() {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            AreEqual(x,GetRepo.service);
            GetRepo.service = s;
        }
    }
}
