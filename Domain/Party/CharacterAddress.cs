using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterAddressesRepo : IRepo<CharacterAddress> { }
    public sealed class CharacterAddress : BaseEntity<CharacterAddressData> {
        public CharacterAddress() : this(new ()) { }
        public CharacterAddress(CharacterAddressData d) : base(d) { }
        public string CharacterID => GetValue(Data?.CharacterID);
        public string AddressID => GetValue(Data?.AddressID);
        public Character? Character => GetRepo.Instance<ICharactersRepo>().Get(CharacterID);
        public Address? Address => GetRepo.Instance<IAddressRepo>().Get(AddressID);
        public AddressUse UseFor => GetValue(Data?.UseFor);
    }
}
