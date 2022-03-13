using System.Diagnostics;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public abstract class BaseTests : IsTypeTested {
        protected object obj;
        protected BaseTests() => obj = CreateObject(); 
        protected abstract object CreateObject(); 
        protected void IsProperty<T>(T? value = default, bool isReadOnly = false) {
            var memberName = GetCallingMember(nameof(IsProperty)).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            IsNotNull(propertyInfo);
            if (IsNullOrDefault(value)) value = Random<T>();
            if (CanWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value); 
            AreEqual(value, propertyInfo.GetValue(obj));
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
            for (int i = 0; i < s.FrameCount - 1; i++) {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        } 
    }
}
