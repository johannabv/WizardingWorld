﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
 
namespace Tests {
    public class AssertTests {
        protected static void IsInconclusive(string? s = null) => Assert.Inconclusive(s?? string.Empty);
        protected static void IsTrue(bool? b, string? message = null) => Assert.IsTrue(b ?? false, message ?? string.Empty);
        protected static void IsFalse(bool? b, string? message = null) => Assert.IsFalse(b ?? true, message ?? string.Empty);
        protected static void IsNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
        protected static void AreEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
        protected static void AreNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
        protected static void IsInstanceofType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
    }
}
