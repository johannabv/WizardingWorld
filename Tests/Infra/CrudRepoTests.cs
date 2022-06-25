using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private CharacterData? data;
        private Character? obj;
        private class TestClass : CrudRepo<Character, CharacterData> {
            public TestClass(DbContext? context, DbSet<CharacterData>? set) : base(context, set) { }
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
            data = GetRandom.Value<CharacterData>();
            IsNotNull(data);
            obj = new Character(data);
            Character x = Obj.Get(data.Id);
            IsNotNull(x);
            AreNotEqual(data.Id, x.Id);
        } 
        private void InitSet() {
            count = GetRandom.Int32(5, 15);
            for(int i = 0; i < count; i++) set?.Add(GetRandom.Value<CharacterData>());
            _ = (db?.SaveChanges());
        }
        [TestMethod] public async Task AddTest() {
            IsNotNull(obj);
            IsNotNull(set);
            _ = Obj?.Add(obj);
            AreEqual(count + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            IsNotNull(obj);
            IsNotNull(set);
            _ = Obj?.AddAsync(obj);
            AreEqual(count + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            IsNotNull(data);
            await GetTest();
            _ = Obj.Delete(data.Id);
            Character entity = Obj.Get(data.Id);
            IsNotNull(entity);
            AreNotEqual(data.Id, entity.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            IsNotNull(data);
            await GetTest();
            _ = Obj.DeleteAsync(data.Id);
            Character entity = Obj.Get(data.Id);
            IsNotNull(entity);
            AreNotEqual(data.Id, entity.Id);
        }
        [TestMethod] public async Task GetTest() {
            IsNotNull(data);
            await AddTest();
            Character entity = Obj.Get(data.Id);
            ArePropertiesEqual(data, entity.Data);
        }
        
        [DataRow(nameof(Character.Id))]
        [DataRow(nameof(Character.FirstName))]
        [DataRow(nameof(Character.LastName))]
        [DataRow(nameof(Character.Organization))]
        [DataRow(nameof(Character.DoB))]
        [DataRow(nameof(Character.Gender))]
        [DataRow(nameof(Character.HogwartsHouse))]
        [DataRow(nameof(Character.ToString))]
        [DataRow(null)]
        [TestMethod] public void GetAllTest(string s) {
            Func<Character, dynamic>? orderBy = null;

            if (s is nameof(Character.Id)) orderBy = x => x.Id;
            else if (s is nameof(Character.FirstName)) orderBy = x => x.FirstName;
            else if (s is nameof(Character.LastName)) orderBy = x => x.LastName;
            else if (s is nameof(Character.Organization)) orderBy = x => x.Organization;
            else if (s is nameof(Character.DoB)) orderBy = x => x.DoB;
            else if (s is nameof(Character.Gender)) orderBy = x => x.Gender;
            else if (s is nameof(Character.HogwartsHouse)) orderBy = x => x.HogwartsHouse;
            else if (s is nameof(Character.ToString)) orderBy = x => x.ToString();

            List<Character> list = Obj.GetAll(orderBy);
            AreEqual(count, list.Count);
            if (orderBy is null) return;

            for (int i = 0; i < list.Count - 1; i++) {
                Character a = list[i];
                Character b = list[i + 1];
                IComparable? aX = orderBy(a) as IComparable;
                IComparable? bX = orderBy(b) as IComparable;
                IsNotNull(aX);
                IsNotNull(bX);
                int r = aX.CompareTo(bX);
                IsTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            List<Character> list = Obj.Get();
            AreEqual(count, list.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            IsNotNull(data);
            await AddAsyncTest();
            Character entity = await Obj.GetAsync(data.Id);
            ArePropertiesEqual(data, entity.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            List<Character> list = await Obj.GetAsync();
            AreEqual(count, list.Count);
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            CharacterData? dX = GetRandom.Value<CharacterData>() as CharacterData;
            IsNotNull(data);
            IsNotNull(dX);
            dX.Id = data.Id;
            Character aX = new(dX);
            _ = Obj.Update(aX);
            Character x = Obj.Get(data.Id);
            ArePropertiesEqual(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            CharacterData? dX = GetRandom.Value<CharacterData>() as CharacterData;
            IsNotNull(data);
            IsNotNull(dX);
            dX.Id = data.Id;
            Character aX = new Character(dX);
            _ = await Obj.UpdateAsync(aX);
            Character x = Obj.Get(data.Id);
            ArePropertiesEqual(dX, x.Data);
        }
    }
}
