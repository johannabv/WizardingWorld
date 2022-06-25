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
    [TestClass] public class BaseRepoTests
        : AbstractClassTests<BaseRepo<Character, CharacterData>, object> {
        private class TestClass : BaseRepo<Character, CharacterData> {
            public TestClass(DbContext? context, DbSet<CharacterData>? set) : base(context, set) { }
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
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            DbSet<CharacterData>? set = db?.Characters;
            IsNotNull(set);
            Obj = new TestClass(db, set);
            AreEqual(db, Obj.Db);
            AreEqual(set, Obj.Set);
        }
        [TestMethod] public async Task ClearTest() {
            BaseRepoTest();
            int cnt = GetRandom.Int32(5, 30);
            DbContext? db = Obj.Db;
            IsNotNull(db);
            DbSet<CharacterData>? set = Obj.Set;
            IsNotNull(set);
            for (int i = 0; i < cnt; i++) set.Add(GetRandom.Value<CharacterData>());
            AreEqual(0, await set.CountAsync());
            db.SaveChanges();
            AreEqual(cnt, await set.CountAsync());
            Obj.Clear();
            AreEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => IsAbstractMethod(nameof(Obj.Add), typeof(Character));
        [TestMethod] public void AddAsyncTest() => IsAbstractMethod(nameof(Obj.AddAsync), typeof(Character));
        [TestMethod] public void DeleteTest() => IsAbstractMethod(nameof(Obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => IsAbstractMethod(nameof(Obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => IsAbstractMethod(nameof(Obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => IsAbstractMethod(nameof(Obj.GetAll), typeof(Func<Character, dynamic>));
        [TestMethod] public void GetListTest() => IsAbstractMethod(nameof(Obj.Get));
        [TestMethod] public void GetAsyncTest() => IsAbstractMethod(nameof(Obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => IsAbstractMethod(nameof(Obj.GetAsync));
        [TestMethod] public void UpdateTest() => IsAbstractMethod(nameof(Obj.Update), typeof(Character));
        [TestMethod] public void UpdateAsyncTest() => IsAbstractMethod(nameof(Obj.UpdateAsync), typeof(Character));
    }
}
