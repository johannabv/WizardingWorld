using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CharacterInitializer : BaseInitializer<CharacterData> {
        public CharacterInitializer(WizardingWorldDb db) : base(db, db?.Characters) { }
        internal static CharacterData CreateCharacter(string firstName, string lastName, bool gender, DateTime DoB, string hogwartsHouse, string organisation) {
            var character = new CharacterData {
                ID = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Organisation = organisation,
                DoB = DoB,
                HogwartsHouse = hogwartsHouse
            };
            return character;
        }
        protected override IEnumerable<CharacterData> GetEntities => new[] {
            CreateCharacter("Harry", "Potter", false, new DateTime(1980,07,31), "Gryffindor", "OoP"),
            CreateCharacter("Draco", "Malfoy", false, new DateTime(1980,04,11), "Slytherin", "Deatheater"),
            CreateCharacter("Remus", "Lupin", false, new DateTime(1967,05,02), "Gryffindor", "OoP")
        };
    }
}
