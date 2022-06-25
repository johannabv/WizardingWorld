using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
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
        private static Type SetType => typeof(DbSet<TData>);
        private WizardingWorldDb WizardingWorldDb {
            get {
                DbContext? context = Obj.Db;
                IsNotNull(context);
                WizardingWorldDb? db = context as WizardingWorldDb;
                IsNotNull(db);
                return db;
            }
        }
        protected void InstanceTest(object? obj, Type type) {
            IsNotNull(obj);
            IsInstanceOfType(obj, type);
        }
        protected void InstanceTest(object? obj, Type type, object? expected) {
            InstanceTest(obj, type);
            InstanceTest(expected, type);
            AreEqual(expected, obj);
        }
        [TestMethod] public void DbContextTest() => InstanceTest(Obj.Db, WizardingWorldType);
        [TestMethod] public void DbSetTest() => InstanceTest(Obj.Set, SetType, GetSet(WizardingWorldDb));
        [TestMethod] public void ToDomainTest() {
            dynamic? data = GetRandom.Value<TData>();
            dynamic? obj = Obj.ToDomain(data);
            IsNotNull(obj);
            IsInstanceOfType(obj, typeof(TDomain));
            ArePropertiesEqual(data, obj.Data);
        }
        [TestMethod] public void AddFilterTest() {
            string Contains(string str) => $"x.{str}.Contains";
            string ToStrContains(string str) => $"x.{str}.ToString().Contains";
            Obj.CurrentFilter = "abc";
            IQueryable<TData> q = Obj.CreateSql();
            string str = q.Expression.ToString();
            foreach (PropertyInfo propertyInfo in typeof(TData).GetProperties()) {
                if (propertyInfo.Name == nameof(BaseData.Token)) continue;
                if (propertyInfo.PropertyType == typeof(string))
                    IsTrue(str.Contains(Contains(propertyInfo.Name)), $"No Where part found for the property {propertyInfo.Name}");
                else
                    IsTrue(str.Contains(ToStrContains(propertyInfo.Name)), $"No Where part found for the property {propertyInfo.Name}");
            }
        }
        protected abstract object? GetSet(WizardingWorldDb db);
    }
}
