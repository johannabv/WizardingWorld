﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
 
namespace Tests {
    public class TestAsserts {
        protected static void isTrue(bool? b, string? message = null) => Assert.IsTrue(b ?? false, message ?? String.Empty);
        protected static void isFalse(bool? b, string? message = null) => Assert.IsFalse(b ?? true, message ?? String.Empty);
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
        protected static void areEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
        protected static void areNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
        protected static void isInstanceOfType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
    }
}
