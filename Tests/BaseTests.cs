using System;
using System.Diagnostics;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public abstract class BaseTests : IsTypeTested
    {
        protected object obj;
        protected BaseTests() => obj = CreateObj();
        protected abstract object CreateObj();
        protected void IsProperty<T>(T? value = default, bool isReadOnly = false)
        {
            var memberName = GetCallingMember(nameof(IsProperty)).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            IsNotNull(propertyInfo);
            if (IsNullOrDefault(value)) value = Random<T>();
            if (CanWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            AreEqual(value, propertyInfo.GetValue(obj));
        }
        private static bool IsNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool CanWrite(PropertyInfo i, bool isReadOnly)
        {
            var canWrite = i?.CanWrite ?? false;
            AreEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T? Random<T>() => GetRandom.Value<T>();
        private static string GetCallingMember(string memberName)
        {
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
    }
}
