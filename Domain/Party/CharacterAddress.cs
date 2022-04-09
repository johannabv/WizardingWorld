using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterAddressesRepo : IRepo<CharacterAddress> { }
    public sealed class CharacterAddress : NamedEntity<CharacterAddressData> {
        public CharacterAddress() : this(new ()) { }
        public CharacterAddress(CharacterAddressData d) : base(d) { }
        public string CharacterID => GetValue(Data?.CharacterID);
        public string AddressID => GetValue(Data?.AddressID);
    }
}
