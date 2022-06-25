using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharactersRepo : IRepo<Character> { }
    public sealed class Character : BaseEntity<CharacterData> {
        public Character() : this(new ()) { }
        public Character(CharacterData d) : base(d) { } 
        public string FirstName =>GetValue(Data?.FirstName);
        public string LastName => GetValue(Data?.LastName);
        public Side Organization => GetValue(Data?.Organization);
        public string HogwartsHouse => GetValue(Data?.HogwartsHouse);
        public IsoGender Gender => GetValue(Data?.Gender);
        public DateTime DoB => GetValue(Data?.DoB); 
        public override string ToString() => $"{FirstName} {LastName}, {Organization} ({Gender.GetDescription()}, {DoB}, {HogwartsHouse})";

        public Lazy<List<CharacterAddress>> CharacterAddresses {
            get {
                List<CharacterAddress> l = GetRepo.Instance<ICharacterAddressesRepo>()?
                      .GetAll(x => x.CharacterId)?
                      .Where(x => x.CharacterId == Id)?
                      .ToList() ?? new List<CharacterAddress>();
                return new Lazy<List<CharacterAddress>>(l);
            }
        }
        public Lazy<List<Address?>> Addresses {
            get {
                List<Address?> l = CharacterAddresses
                    .Value
                    .Select(x => x.Address)
                    .ToList() ?? new List<Address?>();
                return new Lazy<List<Address?>>(l);
            }
        }
    }
}
