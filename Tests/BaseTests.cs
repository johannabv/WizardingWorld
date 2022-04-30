using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using WizardingWorld.Aids;
using WizardingWorld.Domain;

namespace Tests {
    public abstract class BaseTests<TClass, TBaseClass> : TypeTests where TClass : class where TBaseClass : class {
        protected TClass obj;
        protected BaseTests() => obj = CreateObj();
        protected abstract TClass CreateObj();
        protected void IsProperty<T>(T? value = default, bool isReadOnly = false, string? callingMethod = null) {
            callingMethod ??= nameof(IsProperty);
            var actual = GetProperty(ref value, isReadOnly, callingMethod);
            AreEqual(value, actual);
        }
        protected object? GetProperty<T>(ref T? value, bool isReadOnly, string callingMethod) {
            var memberName = GetCallingMember(callingMethod).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            IsNotNull(propertyInfo);
            if (IsNullOrDefault(value)) value = Random<T>();
            if (CanWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            return propertyInfo.GetValue(obj);
        }
        protected object? IsReadOnly<T>(string? callingMethod = null) {
            var v = default(T);
            return GetProperty(ref v, true, callingMethod ?? nameof(IsReadOnly));
        }
        protected void IsReadOnly<T>(T? value) => IsProperty<T>(value, true, nameof(IsReadOnly));
        protected void testItem<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
            where TRepo : class, IRepo<TObj> where TObj : BaseEntity {

            var c = IsReadOnly<TObj>(nameof(testItem));
            IsNotNull(c);
            IsInstanceOfType(c, typeof(TObj));
            var r = GetRepo.Instance<TRepo>();
            var d = GetRandom.Value<TData>();
            d.ID = id;
            var count = GetRandom.Int32(0, 30);
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
        private static bool IsNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool CanWrite(PropertyInfo i, bool isReadOnly) {
            var canWrite = i?.CanWrite ?? false;
            AreEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T? Random<T>() => GetRandom.Value<T>();
        private static string GetCallingMember(string memberName) {
            var s = new StackTrace();
            var isNext = false;
            for (int i = 0; i < s.FrameCount - 1; i++)
            {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        }
        internal protected static void ArePropertiesEqual(object x, object y) {
            var e = Array.Empty<PropertyInfo>();
            var px = x?.GetType()?.GetProperties() ?? e;
            var hasProperties = false;
            foreach (var p in px) {
                var a = p.GetValue(x, null);
                var py = y?.GetType()?.GetProperty(p.Name);
                if (py is null) continue;
                var b = py?.GetValue(y, null);
                AreEqual(a, b);
                hasProperties = true;
            }
            IsTrue(hasProperties, $"No properties found for {x}");
        }
        [TestMethod] public void BaseClassTest() => AreEqual(typeof(TClass).BaseType, typeof(TBaseClass));
    }
}
