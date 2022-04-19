using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public abstract class IsAssemblyTested : TestAsserts  {
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private static string TestsStr => "Tests";
        private static string TestsProjectStr => $"{TestsStr}.";
        private string NotTestedMsg => $"Class \"{FullNameOfFirstNotTested()}\" is not tested";
        [TestMethod] public void IsAllTested() => isAllTested();
        protected virtual void isAllTested() {
            testingAssembly = GetTheAssembly(this);
            testingTypes = GetTypes(testingAssembly);
            namespaceOfTest = GetTheNamespace(this);
            RemoveNotInNamespace(testingTypes, namespaceOfTest);
            RemoveNotClassTests();
            RemoveNotCorrectTests();
            namespaceOfType = RemoveTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = GetTheAssembly(namespaceOfType);
            typesToBeTested = GetTypes(assemblyToBeTested);
            RemoveNotInNamespace(typesToBeTested, namespaceOfType);
            RemoveInterface();
            RemoveNotNeedTesting();
            RemoveDuplications();
            RemoveTested();
            if (AllAreTested()) return;
            ReportNotAllIsTested();
        }

        private void RemoveDuplications() => typesToBeTested?.Find(x => IsItDuplicated(x));

        private bool IsItDuplicated(Type x) {
            var t = typesToBeTested?.Find(y => IsDuplicated(y, x));
            if (t == null) return false;
            _ = typesToBeTested?.Remove(t);
            return t is not null;
        }
        private bool IsDuplicated(Type x, Type y) {
            if (x == y) return false;
            var nameX = x.Name;
            var nameY = y.Name;
            var lengthX = nameX.IndexOf('`');
            var lengthY = nameY.IndexOf('`');
            if (lengthX >= 0) nameX = nameX[..lengthX];
            if (lengthY >= 0) nameY = nameY[..lengthY];
            return nameX == nameY;
        }
        private void RemoveInterface() => typesToBeTested?.RemoveAll(t => t.IsInterface);
        private void RemoveNotClassTests() => testingTypes.Remove(x => !Types.NameEnds(x, TestsStr));
        private void RemoveNotCorrectTests() => testingTypes.Remove(x => !IsCorrectTest(x));
        private static void RemoveNotInNamespace(List<Type>? t, string? nameSpace) => t?.Remove(x => !Types.NameStarts(x, nameSpace));
        private static Assembly? GetTheAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? GetTheAssembly(string? name) => GetAssembly.ByName(name);
        private static string? RemoveTestsTagFrom(string? s) => s?.Remove(TestsProjectStr);
        private static string? GetTheNamespace(object o) => GetNamespace.OfType(o);
        private static List<Type>? GetTypes(Assembly? a) => GetAssembly.Types(a);
        private void ReportNotAllIsTested() => IsInconclusive(NotTestedMsg);
        private string FullNameOfFirstNotTested() => FirstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? FirstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool AllAreTested() => typesToBeTested.IsEmpty();
        private void RemoveTested() => typesToBeTested?.RemoveAll(x => IsItTested(x));
        private bool IsItTested(Type x) {
            var t = testingTypes?.Find(y => IsTestFor(y, x));
            if(t is null) return false;
            _ = testingTypes?.Remove(t);
            return t is not null;
        }
        private static bool IsCorrectTest(Type x) => IsCorrectlyInherited(x) && IsTestClass(x);
        private static bool IsTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool IsCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private static bool IsTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.FullName ?? string.Empty;
            testName = testName.RemoveHead();
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            testName += TestsStr;
            return testingType.NameEnds($".{testName}");
        }
        private void RemoveNotNeedTesting() => typesToBeTested?.Remove(x => !IsTypeToBeTested(x));
        private bool IsTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}
