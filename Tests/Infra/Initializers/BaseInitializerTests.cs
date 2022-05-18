using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializer {
    [TestClass] public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<AddressData>, object> {
        private class testClass : BaseInitializer<AddressData> {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override IEnumerable<AddressData> GetEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<AddressData> CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            DbSet<AddressData>? set = db?.Addresses;
            return new testClass(db, set);
        }

        [TestMethod] public void InitTest() => IsInconclusive();

        [DataRow(null, false)]
        [DataRow("hello", true)]
        [DataRow("555", false)]
        [TestMethod] public void isCorrectIsoCodeTest(string id, bool expected) {
            bool actual = !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
            AreEqual(actual, expected);
        }
    }
}
