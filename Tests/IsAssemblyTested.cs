﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public abstract class IsAssemblyTested : TestAsserts
    {
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;

        [TestMethod] public void IsAllTested() => isAllTested();
        protected virtual void isAllTested() {
            testingAssembly = GetTheAssembly(this);
            testingTypes = GetTypes(testingAssembly);
            namespaceOfTest = GetTheNamespace(this);
            RemoveNotInNamespace();
            namespaceOfType = RemoveTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = GetTheAssembly(namespaceOfType);
            typesToBeTested = GetTypes(assemblyToBeTested);
            RemoveNotNeedTesting();
            RemoveTested();
            if (AllAreTested()) return;
            ReportNotAllIsTested();
        }

        private void RemoveNotInNamespace() => testingTypes.Remove(x => !Types.NameStarts(x, namespaceOfTest));
        private static Assembly? GetTheAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? GetTheAssembly(string? name) => GetAssembly.ByName(name);
        private static string? RemoveTestsTagFrom(string? s) => s?.Remove("Tests.");
        private static string? GetTheNamespace(object o) => GetNamespace.OfType(o);
        private static List<Type>? GetTypes(Assembly? a) => GetAssembly.Types(a);
        private void ReportNotAllIsTested() => IsInconclusive($"Class \"{FullNameOfFirstNotTested()}\" is not tested");
        private string FullNameOfFirstNotTested() => FirstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? FirstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool AllAreTested() => typesToBeTested.IsEmpty();
        private void RemoveTested() => typesToBeTested?.Remove(x => IsItTested(x));
        private bool IsItTested(Type x) => testingTypes?.ContainsItem(y => IsTestFor(y, x) && IsCorrectTest(y)) ?? false;
        private bool IsCorrectTest(Type x) => IsCorrectlyInherited(x) && IsTestClass(x);
        private static bool IsTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool IsCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private static bool IsTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.Name;
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            testName += "Tests";
            return testingType.NameEnds($".{testName}");
        }
        private void RemoveNotNeedTesting() => typesToBeTested?.Remove(x => !IsTypeToBeTested(x));
        private bool IsTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}
