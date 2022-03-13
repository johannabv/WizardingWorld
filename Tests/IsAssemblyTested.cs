using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public abstract class IsAssemblyTested : AssertTests {
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        [TestMethod] public void IsAllTested() => AreAllThingsTested();
        protected virtual void AreAllThingsTested() {
            testingAssembly = GetTheAssembly(this);
            testingTypes = GetAllTypes(testingAssembly);
            namespaceOfTest = GetTheNamespace(this);
            namespaceOfType = RemoveTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = GetTheAssembly(namespaceOfType);
            typesToBeTested = GetAllTypes(assemblyToBeTested);
            RemoveNotNeedTesting();
            RemoveTested();
            if (AreAllTested()) return;
            ReportNotAllIsTested();
        }
        private static List<Type>? GetAllTypes(Assembly? a) => GetAssembly.Types(a);
        private static Assembly? GetTheAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? GetTheAssembly(string? name) => GetAssembly.ByName(name);
        private static string? RemoveTestsTagFrom(string? s) => s?.Remove("Tests.");
        private static string? GetTheNamespace(object o) => GetNamespace.OfType(o);
        private void ReportNotAllIsTested() => IsInconclusive($"Class \"{FullNameOfFirstNotTested()}\" is not tested");
        private string FullNameOfFirstNotTested() => FirstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? FirstNotTestedType(List<Type>? list) => list.GetFirst();
        private bool AreAllTested() => typesToBeTested.IsEmpty();
        private void RemoveTested() => typesToBeTested?.Remove(x => IsItTested(x));
        private bool IsItTested(Type x) => testingTypes?.ContainsItem(y => IsTestFor(y, x) && IsCorrectTest(y)) ?? false;
        private static bool IsCorrectTest(Type x) => IsCorrectlyInherited(x) && IsTestClass(x);
        private static bool IsTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool IsCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private static bool IsTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.Name;
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            testName+= "Tests";
            return testingType.NameEnds(testName);
        }
        private void RemoveNotNeedTesting() => typesToBeTested?.Remove(x => !IsTypeToBeTested(x));
        private bool IsTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    } 
}
