using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<AddressData>, object> {
        private class testClass : BaseInitializer<AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override IEnumerable<AddressData> GetEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<AddressData> CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            var set = db?.Addresses;
            return new testClass(db, set);
        }
    }
}
