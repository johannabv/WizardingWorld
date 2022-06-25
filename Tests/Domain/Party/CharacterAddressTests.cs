using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterAddressTests : SealedClassTests<CharacterAddress, BaseEntity<CharacterAddressData>> {
        protected override CharacterAddress CreateObj() => new(GetRandom.Value<CharacterAddressData>());
        [TestMethod] public void CharacterIdTest() => IsReadOnly(Obj.Data.CharacterId);
        [TestMethod] public void AddressIdTest() => IsReadOnly(Obj.Data.AddressId);
        [TestMethod] public void CharacterTest() 
            => TestItem<ICharactersRepo, Character, CharacterData>(Obj.CharacterId, d => new Character(d), () => Obj.Character);
        [TestMethod] public void AddressTest() 
            => TestItem<IAddressRepo, Address, AddressData>(Obj.AddressId, d => new Address(d), () => Obj.Address);
        [TestMethod] public void UseForTest() => IsReadOnly(Obj.Data.UseFor);
    }
}
