using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
 
namespace Tests {
    public class AssertTests {
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
        protected static void isInstanceofType(object o, Type expectedType) => Assert.IsInstanceOfType(o, expectedType);
    }
}
