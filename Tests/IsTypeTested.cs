using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public class IsTypeTested : AssertTests {
        private string? nameOfTest;
        private string? nameOfType;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private Assembly? assemblyToBeTested;
        private Type? typeToBeTested;
        private List<string>? membersOfType;
        private List<string>? membersOfTest;

        [TestMethod] public void IsAllTested() => isAllTested(); 
        protected virtual void isAllTested() {
            nameOfTest = getName(this);
            nameOfType = removeTestsTagFrom(nameOfTest);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typeToBeTested = getType(assemblyToBeTested, nameOfType);
            membersOfType = getMembers(typeToBeTested);
            membersOfTest = getMembers(GetType());
            removeNotTests(GetType());
            removeNotNeedingTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void reportNotAllIsTested() => isInconclusive($"Member \"{nameOfFirstNotTested()}\" is not tested"); 
        private string nameOfFirstNotTested() => membersOfType?.GetFirst() ?? String.Empty; 
        private bool allAreTested() => membersOfType.IsEmpty();
        private void removeTested() => membersOfType?.Remove(x => isItTested(x)); 
        private bool isItTested(string x) => membersOfTest?.ContainsItem(y => isTestFor(y, x)) ?? false; 
        private static bool isTestFor(string testingMember, string memberToBeTested) => testingMember.Equals(memberToBeTested + "Test");
        private void removeNotNeedingTesting() => membersOfType?.Remove(x => !isTypeToBeTested(x)); 
        private static bool isTypeToBeTested(string x) => x?.IsRealTypeName() ?? false;
        private void removeNotTests(Type type) => membersOfTest?.Remove(x => !isCorrectTestMethod(x, type)); 
        private static bool isCorrectTestMethod(string x, Type type) => isCorrectlyInherited(type) && isTestClass(type) && isTestMethod(x, type); 
        private static bool isTestMethod(string methodName, Type type) =>  type?.Method(methodName).HasAttribute<TestMethodAttribute>() ?? false; 
        private static bool isTestClass(Type type) => type?.HasAttribute<TestClassAttribute>() ?? false; 
        private static bool isCorrectlyInherited(Type t) => t.IsInherited(typeof(IsTypeTested)); 
        private static List<string>? getMembers(Type? type) => type?.DeclaredMembers();
        private static Type? getType(Assembly? a, string? name) => a?.Type(name);
        private static Assembly? getAssembly(string? name) {
            while (!string.IsNullOrWhiteSpace(name)) {
                var a = GetAssembly.ByName(name);
                if (a is not null) return a;
                name = name.RemoveTail();
            }
            return null;
        }
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static string? removeTestsTagFrom(string? s) => s?.Remove("Tests")?.Remove("Test")?.Replace("..",".");
        private static string? getName(object o) => Types.GetName(o?.GetType());
    }
}
