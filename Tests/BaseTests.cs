using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;
using WizardingWorld.Aids;

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
        protected object? IsReadOnly<T>() {
            var v = default(T);
            return GetProperty(ref v, true, nameof(IsReadOnly));
        }
        protected void IsReadOnly<T>(T? value) => IsProperty<T>(value, true, nameof(IsReadOnly));
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
