using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                var o = obj.db;
                IsNotNull(o);
                var db = o as WizardingWorldDb;
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
        [TestMethod] public void DbContextTest() => InstanceTest(obj.db, WizardingWorldType);
        [TestMethod] public void DbSetTest() => InstanceTest(obj.set, setType, GetSet(wizardingWorldDb));
        [TestMethod] public void ToDomainTest() {
            var d = GetRandom.Value<TData>();
            var o = obj.ToDomain(d);
            IsNotNull(o);
            IsInstanceOfType(o, typeof(TDomain));
            ArePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void AddFilterTest() {
            string Contains(string s) => $"x.{s}.Contains";
            string ToStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.CreateSQL();
            var s = q.Expression.ToString();
            foreach (var p in typeof(TData).GetProperties()) {
                if (p.PropertyType == typeof(string))
                    IsTrue(s.Contains(Contains(p.Name)), $"No Where part found for the property {p.Name}");
                else
                    IsTrue(s.Contains(ToStrContains(p.Name)), $"No Where part found for the property {p.Name}");
            }
        }
        protected abstract object? GetSet(WizardingWorldDb db);
    }
}
