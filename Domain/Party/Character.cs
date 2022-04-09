using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterRepo : IRepo<Character> { }
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
    }
}
