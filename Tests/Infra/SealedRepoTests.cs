using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data;
using WizardingWorld.Domain;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData>
        : SealedBaseTests<TClass, TBaseClass>
        where TClass : FilteredRepo<TDomain, TData>
        where TBaseClass : class
        where TDomain : BaseEntity<TData>, new()
        where TData : BaseData, new() {
        private static Type WizardingWorldType => typeof(WizardingWorldDb);
        private static Type setType => typeof(DbSet<TData>);
        private WizardingWorldDb wizardingWorldDb {
            get {
                DbContext? o = obj.Db;
                IsNotNull(o);
                WizardingWorldDb? db = o as WizardingWorldDb;
                IsNotNull(db);
                return db;
            }
        }
        protected void InstanceTest(object? o, Type t) {
            IsNotNull(o);
            IsInstanceOfType(o, t);
        }
        protected void InstanceTest(object? o, Type t, object? expected) {
            InstanceTest(o, t);
            InstanceTest(expected, t);
            AreEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => InstanceTest(obj.Db, WizardingWorldType);
        [TestMethod] public void DbSetTest() => InstanceTest(obj.Set, setType, GetSet(wizardingWorldDb));
        [TestMethod] public void ToDomainTest() {
            dynamic? d = GetRandom.Value<TData>();
            dynamic? o = obj.ToDomain(d);
            IsNotNull(o);
            IsInstanceOfType(o, typeof(TDomain));
            ArePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void AddFilterTest() {
            string contains(string s) => $"x.{s}.Contains";
            string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            IQueryable<TData> q = obj.CreateSQL();
            string s = q.Expression.ToString();
            foreach (PropertyInfo p in typeof(TData).GetProperties()) {
                if (p.Name == nameof(BaseData.Token)) continue;
                if (p.PropertyType == typeof(string))
                    IsTrue(s.Contains(contains(p.Name)), $"No Where part found for the property {p.Name}");
                else
                    IsTrue(s.Contains(toStrContains(p.Name)), $"No Where part found for the property {p.Name}");
            }
        }
        protected abstract object? GetSet(WizardingWorldDb db);
    }
}
