using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterAddressesRepo : IRepo<CharacterAddress> { }
    public sealed class CharacterAddress : BaseEntity<CharacterAddressData> {
        public CharacterAddress() : this(new ()) { }
        public CharacterAddress(CharacterAddressData d) : base(d) { }
        public string CharacterId => GetValue(Data?.CharacterId);
        public string AddressId => GetValue(Data?.AddressId);
        public Character? Character => GetRepo.Instance<ICharactersRepo>()?.Get(CharacterId);
        public Address? Address => GetRepo.Instance<IAddressRepo>()?.Get(AddressId);
        public AddressUse UseFor => GetValue(Data?.UseFor);
    }
}
