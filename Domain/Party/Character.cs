using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterRepo : IRepo<Character> { }
    public sealed class Character : Entity<CharacterData> {
        public Character() : this(new CharacterData()) { }
        public Character(CharacterData d) : base(d) { } 
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public string Organisation => Data?.Organisation ?? defaultStr;
        public string HogwartsHouse => Data?.HogwartsHouse ?? defaultStr;
        public bool Gender => Data?.Gender ?? defaultGender;
        public DateTime DoB => Data?.DoB ?? defaultDate; 
        public override string ToString() => $"{FirstName} {LastName}, {Organisation} ({Gender}, {DoB}, {HogwartsHouse})";
    }
}
