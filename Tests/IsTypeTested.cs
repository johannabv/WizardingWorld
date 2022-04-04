﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using WizardingWorld.Aids;

namespace Tests {
    public class IsTypeTested : TestAsserts {
        //private string? nameOfTest;
        //private string? nameOfType;
        //private string? namespaceOfTest;
        //private string? namespaceOfType;
        //private Assembly? assemblyToBeTested;
        //private Type? typeToBeTested;
        //private List<string>? membersOfType;
        //private List<string>? membersOfTest;

        //[TestMethod] public void IsAllTested() => AreAllThingsTested();
        //protected virtual void AreAllThingsTested() {
        //    nameOfTest = GetName(this);
        //    nameOfType = RemoveTestsTagFrom(nameOfTest);
        //    namespaceOfTest = GetTheNamespace(this);
        //    namespaceOfType = RemoveTestsTagFrom(namespaceOfTest);
        //    assemblyToBeTested = getAssembly(namespaceOfType);
        //    typeToBeTested = getType(assemblyToBeTested, nameOfType);
        //    membersOfType = GetMembers(typeToBeTested);
        //    membersOfTest = GetMembers(GetType());
        //    RemoveNotTests(GetType());
        //    RemoveNotNeedTesting();
        //    RemoveTested();
        //    if (AllAreTested()) return;
        //    ReportNotAllIsTested();
        //}

        //private void ReportNotAllIsTested() => IsInconclusive($"Member \"{NameOfFirstNotTested()}\" is not tested");
        //private string NameOfFirstNotTested() => membersOfType?.GetFirst() ?? string.Empty;
        //private bool AllAreTested() => membersOfType.IsEmpty();
        //private void RemoveTested() => membersOfType?.Remove(x => IsItTested(x));
        //private bool IsItTested(string x) => membersOfTest?.ContainsItem(y => IsTestFor(y, x)) ?? false;
        //private static bool IsTestFor(string testingMember, string memberToBeTested)
        //     => testingMember.Equals(memberToBeTested + "Test");
        //private void RemoveNotNeedTesting() => membersOfType?.Remove(x => !IsTypeToBeTested(x));
        //private static bool IsTypeToBeTested(string x) => x?.IsTypeName() ?? false;
        //private void RemoveNotTests(Type t) => membersOfTest?.Remove(x => !IsCorrectTestMethod(x, t));
        //private static bool IsCorrectTestMethod(string x, Type t) => IsCorrectlyInherited(t) && IsTestClass(t) && IsTestMethod(x, t);
        //private static bool IsTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        //private static bool IsTestMethod(string methodName, Type t) => t?.Method(methodName).HasAttribute<TestMethodAttribute>() ?? false;
        //private static bool IsCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        //private static List<string>? GetMembers(Type? t) => t?.DeclaredMembers();
        //private static Type? getType(Assembly? a, string? name) {
        //    if (string.IsNullOrWhiteSpace(name)) return null;
        //    foreach (var t in a?.DefinedTypes ?? Array.Empty<TypeInfo>())
        //        if (t.Name.StartsWith(name)) return t.AsType();
        //    return null;
        //}
        //private static Assembly? getAssembly(string? name) {
        //    while (!string.IsNullOrWhiteSpace(name)) {
        //        var a = GetAssembly.ByName(name);
        //        if (a is not null) return a;
        //        name = name.RemoveTail();
        //    }
        //    return null;
        //}
        //private static string? GetTheNamespace(object o) => GetNamespace.OfType(o);
        //private static string? RemoveTestsTagFrom(string? s) => s?.Remove("Tests")?.Remove("Test")?.Replace("..", ".");
        //private static string? GetName(object o) => Types.GetName(o?.GetType());

        private string? nameOfTest;
        private string? nameOfType;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private Assembly? assemblyToBeTested;
        private Type? typeToBeTested;
        private List<string>? membersOfType;
        private List<string>? membersOfTest;

        [TestMethod] public void IsAllTested() => isAllTested();
        protected virtual void isAllTested()
        {
            nameOfTest = getName(this);
            nameOfType = removeTestsTagFrom(nameOfTest);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typeToBeTested = getType(assemblyToBeTested, nameOfType);
            membersOfType = getMembers(typeToBeTested);
            membersOfTest = getMembers(GetType());
            removeNotTests(GetType());
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void reportNotAllIsTested() => IsInconclusive($"Member \"{nameOfFirstNotTested()}\" is not tested");
        private string nameOfFirstNotTested() => membersOfType?.GetFirst() ?? string.Empty;
        private bool allAreTested() => membersOfType.IsEmpty();
        private void removeTested() => membersOfType?.Remove(x => isItTested(x));
        private bool isItTested(string x) => membersOfTest?.ContainsItem(y => isTestFor(y, x)) ?? false;
        private static bool isTestFor(string testingMember, string memberToBeTested)
             => testingMember.Equals(memberToBeTested + "Test");
        private void removeNotNeedTesting() => membersOfType?.Remove(x => !isTypeToBeTested(x));
        private static bool isTypeToBeTested(string x) => x?.IsTypeName() ?? false;
        private void removeNotTests(Type t) => membersOfTest?.Remove(x => !isCorrectTestMethod(x, t));
        private static bool isCorrectTestMethod(string x, Type t) => isCorrectlyInherited(t) && isTestClass(t) && isTestMethod(x, t);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isTestMethod(string methodName, Type t) => t?.Method(methodName).HasAttribute<TestMethodAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));

        private static List<string>? getMembers(Type? t) => t?.DeclaredMembers();
        // private static Type? getType(Assembly? a, string? name) => a?.Type(name);
        private static Type? getType(Assembly? a, string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            foreach (var t in a?.DefinedTypes ?? Array.Empty<TypeInfo>())
                if (t.Name.StartsWith(name)) return t.AsType();
            return null;
        }
        private static Assembly? getAssembly(string? name)
        {
            while (!string.IsNullOrWhiteSpace(name))
            {
                var a = GetAssembly.ByName(name);
                if (a is not null) return a;
                name = name.RemoveTail();
            }
            return null;
        }
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static string? removeTestsTagFrom(string? s) => s?.Remove("Tests")?.Remove("Test")?.Replace("..", ".");
        private static string? getName(object o) => Types.GetName(o?.GetType());
    }
}
