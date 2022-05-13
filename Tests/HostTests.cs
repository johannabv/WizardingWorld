using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WizardingWorld.Aids;
using WizardingWorld.Data;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace Tests {
    public abstract class HostTests : AssertTests {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        [TestInitialize] public virtual void TestInitialize() {
            (GetRepo.Instance<ICountriesRepo>() as CountriesRepo)?.Clear();
            (GetRepo.Instance<ICharactersRepo>() as CharactersRepo)?.Clear();
            (GetRepo.Instance<IAddressRepo>() as AddressesRepo)?.Clear();
            (GetRepo.Instance<ICurrenciesRepo>() as CurrenciesRepo)?.Clear();
            (GetRepo.Instance<ICountryCurrenciesRepo>() as CountryCurrenciesRepo)?.Clear();
            (GetRepo.Instance<ICharacterAddressesRepo>() as CharacterAddressesRepo)?.Clear();
            (GetRepo.Instance<IWandsRepo>() as WandsRepo)?.Clear();
            (GetRepo.Instance<IWoodsRepo>() as WoodsRepo)?.Clear();
            (GetRepo.Instance<ICoreMaterialsRepo>() as CoreMaterialsRepo)?.Clear();
        }
        static HostTests() {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
        protected virtual object? IsReadOnly<T>(string? callingMethod = null) => null;

        protected void TestList<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
            where TRepo : class, IRepo<TObj> where TObj : BaseEntity<TData> where TData : BaseData, new() {

            var o = IsReadOnly<List<TObj>>(nameof(TestList));
            IsNotNull(o);
            IsInstanceOfType(o, typeof(List<TObj>));
            var r = GetRepo.Instance<TRepo>();
            IsNotNull(r);
            var list = new List<TData>();
            var count = GetRandom.Int32(5, 30);
            for (var i = 0; i < count; i++) {
                var x = GetRandom.Value<TData>();
                if (GetRandom.Bool()) {
                    setId(x);
                    list.Add(x);
                }
                r.Add(toObj(x));
            }
            r.PageSize = 30;
            AreEqual(count, r.Get().Count);
            var l = getList();
            AreEqual(list.Count, l.Count);
            foreach (var d in list) {
                var y = l.Find(z => z.ID == d.ID);
                IsNotNull(y);
                ArePropertiesEqual(d, y);
            }
        }
        protected void TestItem<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
            where TRepo : class, IRepo<TObj> where TObj : BaseEntity {

            var c = IsReadOnly<TObj>(nameof(TestItem));
            IsNotNull(c);
            IsInstanceOfType(c, typeof(TObj));
            var r = GetRepo.Instance<TRepo>();
            var d = GetRandom.Value<TData>();
            d.ID = id;
            var count = GetRandom.Int32(5, 30);
            var index = GetRandom.Int32(0, count);
            for (int i = 0; i < count; i++) {
                var x = (i == index) ? d : GetRandom.Value<TData>();
                IsNotNull(x);
                r?.Add(toObj(x));
            }
            r.PageSize = 30;
            AreEqual(count, r.Get().Count);
            ArePropertiesEqual(d, getObj());
        }
        protected void TestRelatedLists<TRepo, TRelatedItem, TItem, TData>
            (Action relatedTest,
            Func<List<TRelatedItem>> relatedItems,
            Func<List<TItem?>> items,
            Func<TRelatedItem, string> detailID,
            Func<TData, TItem> toObj,
            Func<TItem?, TData?> toData,
            Func<TRelatedItem?, TData?> relatedToData)
            where TRepo : class, IRepo<TItem>
            where TItem : BaseEntity
            where TRelatedItem : BaseEntity {

            relatedTest();
            var list = relatedItems();
            var r = GetRepo.Instance<TRepo>();
            foreach (var e in list) {
                var y = GetRandom.Value<TData>();
                if (y is not null) y.ID = detailID(e);
                r?.Add(toObj(y));
            }
            var characters = items();
            AreEqual(list.Count, characters.Count);
            foreach (var e in list) {
                var a = characters.Find(x => x?.ID == detailID(e));
                ArePropertiesEqual(toData(a), relatedToData(e));
            }
        }
    }
}
