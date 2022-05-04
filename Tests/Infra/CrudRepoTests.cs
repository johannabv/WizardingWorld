using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class CrudRepoTests
        : AbstractClassTests<CrudRepo<Character, CharacterData>, BaseRepo<Character, CharacterData>> {
        private WizardingWorldDb? db;
        private DbSet<CharacterData>? set;
        private int count;
        private CharacterData? d;
        private Character? a;
        private class TestClass : CrudRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            protected internal override Character ToDomain(CharacterData d) => new(d);
        }
        protected override CrudRepo<Character, CharacterData> CreateObj() {
            db = GetRepo.Instance<WizardingWorldDb>();
            set = db?.Characters;
            IsNotNull(set);
            return new TestClass(db, set);
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            InitSet();
            InitCharacter();
        } 
        private void InitCharacter() {
            d = GetRandom.Value<CharacterData>();
            IsNotNull(d);
            a = new Character(d);
            var x = obj.Get(d.ID);
            IsNotNull(x);
            AreNotEqual(d.ID, x.ID);
        } 
        private void InitSet() {
            count = GetRandom.Int32(5, 15);
            for(int i = 0; i < count; i++) set?.Add(GetRandom.Value<CharacterData>());
            _ = (db?.SaveChanges());
        }
        [TestMethod] public async Task AddTest() {
            IsNotNull(a);
            IsNotNull(set);
            _ = obj?.Add(a);
            AreEqual(count + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            IsNotNull(a);
            IsNotNull(set);
            _ = obj?.AddAsync(a);
            AreEqual(count + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            IsNotNull(d);
            await GetTest();
            _ = obj.Delete(d.ID);
            var x = obj.Get(d.ID);
            IsNotNull(x);
            AreNotEqual(d.ID, x.ID);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            IsNotNull(d);
            await GetTest();
            _ = obj.DeleteAsync(d.ID);
            var x = obj.Get(d.ID);
            IsNotNull(x);
            AreNotEqual(d.ID, x.ID);
        }
        [TestMethod] public async Task GetTest() {
            IsNotNull(d);
            await AddTest();
            var x = obj.Get(d.ID);
            ArePropertiesEqual(d, x.Data);
        }
        
        [DataRow(nameof(Character.ID))]
        [DataRow(nameof(Character.FirstName))]
        [DataRow(nameof(Character.LastName))]
        [DataRow(nameof(Character.Organisation))]
        [DataRow(nameof(Character.DoB))]
        [DataRow(nameof(Character.Gender))]
        [DataRow(nameof(Character.HogwartsHouse))]
        [DataRow(nameof(Character.ToString))]
        [DataRow(null)]
        [TestMethod] public void GetAllTest(string s) {
            Func<Character, dynamic>? orderBy = null;
            if (s is nameof(Character.ID)) orderBy = x => x.ID;
            else if (s is nameof(Character.FirstName)) orderBy = x => x.FirstName;
            else if (s is nameof(Character.LastName)) orderBy = x => x.LastName;
            else if (s is nameof(Character.Organisation)) orderBy = x => x.Organisation;
            else if (s is nameof(Character.DoB)) orderBy = x => x.DoB;
            else if (s is nameof(Character.Gender)) orderBy = x => x.Gender;
            else if (s is nameof(Character.HogwartsHouse)) orderBy = x => x.HogwartsHouse;
            else if (s is nameof(Character.ToString)) orderBy = x => x.ToString();
            var l = obj.GetAll(orderBy);
            AreEqual(count, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++) {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                IsNotNull(aX);
                IsNotNull(bX);
                var r = aX.CompareTo(bX);
                IsTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            AreEqual(count, l.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            IsNotNull(d);
            await AddAsyncTest();
            var x = await obj.GetAsync(d.ID);
            ArePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            AreEqual(count, l.Count);
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<CharacterData>() as CharacterData;
            IsNotNull(d);
            IsNotNull(dX);
            dX.ID = d.ID;
            var aX = new Character(dX);
            _ = obj.Update(aX);
            var x = obj.Get(d.ID);
            ArePropertiesEqual(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<CharacterData>() as CharacterData;
            IsNotNull(d);
            IsNotNull(dX);
            dX.ID = d.ID;
            var aX = new Character(dX);
            _ = await obj.UpdateAsync(aX);
            var x = obj.Get(d.ID);
            ArePropertiesEqual(dX, x.Data);
        }
    }
}
