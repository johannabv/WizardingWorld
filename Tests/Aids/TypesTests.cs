using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class TypesTests : TypeTests {
        private Type type = typeof(object);
        private string? nameSpace;
        private string? fullName;
        private string? name;
        private string? randomStr;
        [TestInitialize] public void Init() {
            type = typeof(CountryData);
            nameSpace = type.Namespace;
            fullName = type.FullName;
            name = type.Name;
            randomStr = GetRandom.String();
        }
        [TestMethod] public void BelongsToTest() {
            IsTrue(type.BelongsTo(nameSpace));
            IsFalse(type.BelongsTo(randomStr));
        }
        [TestMethod] public void NameIsTest() {
            IsTrue(type.NameIs(fullName));
            IsFalse(type.NameIs(randomStr));
        }
        [TestMethod] public void NameEndsTest() {
            IsTrue(type.NameEnds(name));
            IsFalse(type.NameEnds(randomStr));
        }
        [TestMethod] public void NameStartsTest() {
            IsTrue(type.NameStarts(nameSpace));
            IsFalse(type.NameStarts(randomStr));
        }
        [TestMethod] public void IsRealTypeTest() {
            IsTrue(type.IsRealType());
            IsTrue(typeof(NamedData).IsRealType());
            Assembly? a = GetAssembly.OfType(this);
            List<Type>? allTypes = (a?.GetTypes() ?? Array.Empty<Type>()).ToList();
            List<Type>? realTypes = allTypes?.FindAll(t => t.IsRealType());
            IsNotNull(realTypes);
            IsTrue(realTypes.Count < (allTypes?.Count ?? 0));
            IsTrue(realTypes.Count > 0);
        }
        [TestMethod] public void GetNameTest() {
            AreEqual(name, type.GetName());
            AreNotEqual(randomStr, type.GetName());
        }
        [TestMethod] public void DeclaredMembersTest() {
            AreEqual(1, type?.GetDeclaredMembers()?.Count);
            List<string>? l = typeof(NamedData)?.GetDeclaredMembers();
            AreEqual(9, l?.Count);
        }
        [TestMethod] public void IsInheritedTest() {
            Type? nullType = null;
            IsTrue(type.IsInherited(typeof(object)));
            IsTrue(type.IsInherited(typeof(NamedData)));
            IsFalse(type.IsInherited(nullType));
            IsFalse(type.IsInherited(typeof(CurrencyData)));
        }
        [TestMethod] public void HasAttributeTest() {
            IsFalse(type.HasAttribute<TestClassAttribute>());
            IsTrue(GetType().HasAttribute<TestClassAttribute>());
            IsFalse(type.HasAttribute<TestMethodAttribute>());
            IsFalse(GetType().HasAttribute<TestMethodAttribute>());
        }
        [TestMethod] public void MethodTest() {
            string n = nameof(MethodTest);
            MethodInfo? m = Types.GetMethod(GetType(), n);
            AreEqual(n, m?.Name);
        }
    }
}
