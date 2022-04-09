using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharactersRepo : IRepo<Character> { }
    public sealed class Character : BaseEntity<CharacterData> {
        public Character() : this(new ()) { }
        public Character(CharacterData d) : base(d) { } 
        public string FirstName =>GetValue(Data?.FirstName);
        public string LastName => GetValue(Data?.LastName);
        public string Organisation => GetValue(Data?.Organisation);
        public string HogwartsHouse => GetValue(Data?.HogwartsHouse);
        public IsoGender Gender => GetValue(Data?.Gender);
        public DateTime DoB => GetValue(Data?.DoB); 
        public override string ToString() => $"{FirstName} {LastName}, {Organisation} ({Gender.Description()}, {DoB}, {HogwartsHouse})";
        public List<CharacterAddress> CharacterAddresses
            => GetRepo.Instance<ICharacterAddressesRepo>()?
            .GetAll(x => x.CharacterID)?
            .Where(x => x.CharacterID == ID)?
            .ToList() ?? new List<CharacterAddress>();

        public List<Address?> Addresses
            => CharacterAddresses
            .Select(x => x.Address)
            .ToList() ?? new List<Address?>();
    }
}
