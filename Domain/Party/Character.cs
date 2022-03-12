using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICharacterRepo : IRepo<Character> { }
    public sealed class Character : Entity<CharacterData> {
        public Character() : this(new CharacterData()) { }
        public Character(CharacterData d) : base(d) { } 
        public string FirstName =>getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string Organisation => getValue(Data?.Organisation);
        public string HogwartsHouse => getValue(Data?.HogwartsHouse);
        public bool Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB); 
        public override string ToString() => $"{FirstName} {LastName}, {Organisation} ({Gender}, {DoB}, {HogwartsHouse})";
    }
}
