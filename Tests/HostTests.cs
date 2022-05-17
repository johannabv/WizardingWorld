using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            object? o = IsReadOnly<List<TObj>>(nameof(TestList));

            IsNotNull(o);
            if (o.GetType().Name.Contains("Lazy")) IsInstanceOfType(o, typeof(Lazy<List<TObj>>));
            else IsInstanceOfType(o, typeof(List<TObj>));

            TRepo? r = GetRepo.Instance<TRepo>();
            IsNotNull(r);

            List<TData> list = new List<TData>();
            int count = GetRandom.Int32(5, 30);

            for (int i = 0; i < count; i++) {
                dynamic? x = GetRandom.Value<TData>();
                if (GetRandom.Bool()) {
                    setId(x);
                    list.Add(x);
                }
                r.Add(toObj(x));
            }

            r.PageSize = 30;
            AreEqual(count, r.Get().Count);

            List<TObj> l = getList();
            AreEqual(list.Count, l.Count);

            foreach (TData d in list) {
                TObj? y = l.Find(z => z.ID == d.ID);
                IsNotNull(y);
                ArePropertiesEqual(d, y, nameof(BaseData.Token));
            }
        }
        protected void TestItem<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
            where TRepo : class, IRepo<TObj> where TObj : BaseEntity {

            object? obj = IsReadOnly<TObj>(nameof(TestItem));
            IsNotNull(obj);
            IsInstanceOfType(obj, typeof(TObj));

            TRepo? repo = GetRepo.Instance<TRepo>();
            int count;
            TData? items = AddRandomItems(out count, toObj, id, repo);
            
            repo.PageSize = 30;
            AreEqual(count, repo.Get().Count);
            ArePropertiesEqual(items, getObj(), nameof(BaseData.Token));
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
            List<TRelatedItem> list = relatedItems();
            TRepo? repo = GetRepo.Instance<TRepo>();
            foreach (TRelatedItem e in list) {
                dynamic? y = GetRandom.Value<TData>();
                if (y is not null) y.ID = detailID(e);
                repo?.Add(toObj(y));
            }
            List<TItem?> characters = items();
            AreEqual(list.Count, characters.Count);
            foreach (TRelatedItem e in list) {
                TItem? a = characters.Find(x => x?.ID == detailID(e));
                ArePropertiesEqual(toData(a), relatedToData(e), nameof(BaseData.Token));
            }
        }
        internal static TData? AddRandomItems<TRepo, TObj, TData>(out int cnt, Func<TData, TObj> toObj, string? id = null, TRepo? r = null)
            where TRepo : class, IRepo<TObj>
            where TObj : BaseEntity {
            r ??= GetRepo.Instance<TRepo>();
            dynamic? d = GetRandom.Value<TData>();
            if (id is not null && d is not null) d.ID = id;
            cnt = GetRandom.Int32(5, 30);
            int idx = GetRandom.Int32(0, cnt);
            for (int i = 0; i < cnt; i++) {
                dynamic? x = (i == idx) ? d : GetRandom.Value<TData>();
                IsNotNull(x);
                r?.Add(toObj(x));
            }
            return d;
        }
        protected static string GetCallingMember(string memberName) {
            StackTrace s = new();
            bool isNext = false;
            for (int i = 0; i < s.FrameCount - 1; i++) {
                string n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        }
    }
}
