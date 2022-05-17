using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests {
    public abstract class BaseTests<TClass, TBaseClass> : TypeTests where TClass : class where TBaseClass : class {
        protected TClass obj;
        private readonly BindingFlags AllFlags = BindingFlags.Public
            | BindingFlags.NonPublic
            | BindingFlags.Instance
            | BindingFlags.Static;
        protected BaseTests() => obj = CreateObj();
        protected abstract TClass CreateObj();
        protected void IsProperty<T>(T? value = default, bool isReadOnly = false, string? callingMethod = null) {
            callingMethod ??= nameof(IsProperty);
            object? actual = GetProperty(ref value, isReadOnly, callingMethod);
            AreEqual(value, actual);
        }
        protected PropertyInfo? IsDisplayNamed<T>(string? displayName = null, T? value = default, bool isReadOnly = false, string? callingMethod = null) {
            callingMethod ??= nameof(IsDisplayNamed);
            PropertyInfo? propertyInfo = GetPropertyInfo(callingMethod);
            IsProperty(value, isReadOnly, callingMethod);
            if (propertyInfo is null) return propertyInfo;
            DisplayNameAttribute? a = propertyInfo.GetAttribute<DisplayNameAttribute>();
            AreEqual(displayName, a?.DisplayName, nameof(DisplayNameAttribute));
            return propertyInfo;
        }
        protected void IsRequired<T>(string? displayName = null, T? value = default, bool isReadOnly = false) {
            PropertyInfo? propertyInfo = IsDisplayNamed(displayName, value, isReadOnly, nameof(IsRequired));
            IsTrue(propertyInfo?.HasAttribute<RequiredAttribute>(), nameof(RequiredAttribute));
        }
        protected PropertyInfo? GetPropertyInfo(string callingMethod) {
            string memberName = GetCallingMember(callingMethod).Replace("Test", string.Empty);
            return obj.GetType().GetProperty(memberName, AllFlags);
            
        }
        protected object? GetProperty<T>(ref T? value, bool isReadOnly, string callingMethod) {
            PropertyInfo? propertyInfo = GetPropertyInfo(callingMethod);
            IsNotNull(propertyInfo);
            if (!isReadOnly && IsNullOrDefault(value)) value = Random<T>();
            if (CanWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            return propertyInfo.GetValue(obj);
        }
        protected override object? IsReadOnly<T>(string? callingMethod = null) {
            T? v = default(T);
            return GetProperty(ref v, true, callingMethod ?? nameof(IsReadOnly));
        }
        protected void IsReadOnly<T>(T? value) => IsProperty(value, true, nameof(IsReadOnly));
        private static bool IsNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool CanWrite(PropertyInfo i, bool isReadOnly) {
            bool canWrite = i?.CanWrite ?? false;
            AreEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T? Random<T>() => GetRandom.Value<T>();
        
        internal protected static new void ArePropertiesEqual(object? x, object? y) {
            PropertyInfo[] e = Array.Empty<PropertyInfo>();
            PropertyInfo[] px = x?.GetType()?.GetProperties() ?? e;
            bool hasProperties = false;
            foreach (PropertyInfo p in px) {
                object? a = p.GetValue(x, null);
                PropertyInfo? py = y?.GetType()?.GetProperty(p.Name);
                if (py is null) continue;
                object? b = py?.GetValue(y, null);
                AreEqual(a, b);
                hasProperties = true;
            }
            IsTrue(hasProperties, $"No properties found for {x}");
        }
        [TestMethod] public void BaseClassTest() => AreEqual(typeof(TClass).BaseType, typeof(TBaseClass));
        protected void IsAbstractMethod(string name, params Type[] args) {
            MethodInfo? mi = typeof(TClass).GetMethod(name, args);
            AreEqual(true, mi?.IsAbstract, name);
        }
    }
}
