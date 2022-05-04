using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class BaseRepoTests
        : AbstractClassTests<BaseRepo<Character, CharacterData>, object> {
        private class TestClass : BaseRepo<Character, CharacterData> {
            public TestClass(DbContext? c, DbSet<CharacterData>? s) : base(c, s) { }
            public override bool Add(Character obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Character obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Character> Get() => throw new NotImplementedException();
            public override Character Get(string id) => throw new NotImplementedException();
            public override List<Character> GetAll(Func<Character, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<Character>> GetAsync() => throw new NotImplementedException();
            public override Task<Character> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(Character obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Character obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Character, CharacterData> CreateObj() => new TestClass(null, null);
        [TestMethod] public void DbTest() => IsReadOnly<DbContext?>();
        [TestMethod] public void SetTest() => IsReadOnly<DbSet<CharacterData>?>();
        [TestMethod] public void BaseRepoTest() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            var set = db?.Characters;
            IsNotNull(set);
            obj = new TestClass(db, set);
            AreEqual(db, obj.Db);
            AreEqual(set, obj.Set);
        }
        [TestMethod] public async Task ClearTest() {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.Db;
            IsNotNull(db);
            var set = obj.Set;
            IsNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<CharacterData>());
            AreEqual(0, await set.CountAsync());
            db.SaveChanges();
            AreEqual(cnt, await set.CountAsync());
            obj.Clear();
            AreEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => IsAbstractMethod(nameof(obj.Add), typeof(Character));
        [TestMethod] public void AddAsyncTest() => IsAbstractMethod(nameof(obj.AddAsync), typeof(Character));
        [TestMethod] public void DeleteTest() => IsAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => IsAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => IsAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => IsAbstractMethod(nameof(obj.GetAll), typeof(Func<Character, dynamic>));
        [TestMethod] public void GetListTest() => IsAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAsyncTest() => IsAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => IsAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => IsAbstractMethod(nameof(obj.Update), typeof(Character));
        [TestMethod] public void UpdateAsyncTest() => IsAbstractMethod(nameof(obj.UpdateAsync), typeof(Character));
    }
}
