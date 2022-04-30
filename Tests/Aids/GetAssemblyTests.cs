using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class GetAssemblyTests : TypeTests {
        private string? assemblyName;
        private Assembly? assembly;
        private string[] typeNames = Array.Empty<string>();
        [TestInitialize] public void Init() {
            assemblyName = $"{nameof(WizardingWorld)}.{nameof(WizardingWorld.Aids)}";
            assembly = GetAssembly.ByName(assemblyName);
            typeNames = new string[] { nameof(Chars), nameof(Enums), nameof(Lists),
                nameof(Strings), nameof(Safe), nameof(Types) };
        }
        [TestCleanup] public void Clean() {
            IsNotNull(assembly);
            AreEqual(assemblyName, assembly.GetName().Name);
        }
        [TestMethod] public void ByNameTest() { }
        [TestMethod]  public void OfTypeTest() {
            assemblyName = $"{nameof(WizardingWorld)}.{nameof(Data)}";
            assembly = GetAssembly.OfType(new CountryData());
        }
        [TestMethod] public void TypesTest() {
            var l = GetAssembly.Types(assembly);
            IsTrue(typeNames.Length < (l?.Count ?? -2));
            foreach (var name in typeNames) AreEqual(l?.FirstOrDefault(x => x.Name == name)?.Name, name);
            IsNull(l?.FirstOrDefault(x => x.Name == GetRandom.String()));
        }
        [TestMethod] public void TypeTest() {
            var n = RandomTypeName;
            var obj = assembly.Type(n);
            IsNotNull(obj);
            AreEqual(n, obj.Name);
        }
        private string RandomTypeName => typeNames[GetRandom.Int32(0, typeNames.Length)];
    }
}

