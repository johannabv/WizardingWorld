using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterAddressRepo : IRepo<CharacterAddress> { }
    public sealed class CharacterAddress : NamedEntity<CharacterAddressData> {
        public CharacterAddress() : this(new ()) { }
        public CharacterAddress(CharacterAddressData d) : base(d) { }
        public string CharacterID => GetValue(Data?.CharacterID);
        public string PlaceID => GetValue(Data?.PlaceID);
    }
}
