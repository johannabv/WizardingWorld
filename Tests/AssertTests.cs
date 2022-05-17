using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Tests {
    public abstract class AssertTests {
        protected static void IsTrue(bool? b, string? message = null) => Assert.IsTrue(b ?? false, message ?? String.Empty);
        protected static void IsFalse(bool? b, string? message = null) => Assert.IsFalse(b ?? true, message ?? String.Empty);
        protected static void IsInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void IsNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
        protected static void IsNull(object? o = null, string? message = null) => Assert.IsNull(o, message);
        protected static void AreEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
        protected static void AreNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
        protected static void IsInstanceOfType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
        protected static void ArePropertiesEqual(object? a, object? b, params string[] exclude) {
            IsNotNull(a);
            IsNotNull(b);
            Type? typeA = a.GetType();
            Type? typeB = b.GetType();
            foreach (PropertyInfo piA in typeA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                if(exclude?.Contains(piA.Name) ?? false) continue;
                object? valueA = piA.GetValue(a, null);
                PropertyInfo? piB = typeB?.GetProperty(piA.Name);
                object? valueB = piB?.GetValue(b, null);
                AreEqual(valueA, valueB, $"for property {piA.Name}.");
            }
        }
    }
}
