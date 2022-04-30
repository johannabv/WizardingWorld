﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Tests {
    public class AssertTests {
        protected static void IsTrue(bool? b, string? message = null) => Assert.IsTrue(b ?? false, message ?? String.Empty);
        protected static void IsFalse(bool? b, string? message = null) => Assert.IsFalse(b ?? true, message ?? String.Empty);
        protected static void IsInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void IsNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
        protected static void IsNull(object? o = null, string? message = null) => Assert.IsNull(o, message);
        protected static void AreEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
        protected static void AreNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
        protected static void IsInstanceOfType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
        protected static void ArePropertiesEqual(object? a, object? b) {
            IsNotNull(a);
            IsNotNull(b);
            var typeA = a.GetType();
            var typeB = b.GetType();
            foreach (var piA in typeA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                var valueA = piA.GetValue(a, null);
                var piB = typeB?.GetProperty(piA.Name);
                var valueB = piB?.GetValue(b, null);
                AreEqual(valueA, valueB, $"for property {piA.Name}.");
            }
        }
    }
}
