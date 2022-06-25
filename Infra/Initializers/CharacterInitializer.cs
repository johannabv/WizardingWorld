using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CharacterInitializer : BaseInitializer<CharacterData> {
        public CharacterInitializer(WizardingWorldDb? db) : base(db, db?.Characters) { }
        internal static CharacterData CreateCharacter(string firstName, string lastName, IsoGender gender, DateTime doB, string hogwartsHouse, Side organization) {
            CharacterData character = new() {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Organization = organization,
                DoB = doB,
                HogwartsHouse = hogwartsHouse
            };
            return character;
        }
        protected override IEnumerable<CharacterData> GetEntities => new[] {
            CreateCharacter("Harry", "Potter", IsoGender.Male, new DateTime(1980,07,31), "Gryffindor", Side.OoP),
            CreateCharacter("Draco", "Malfoy", IsoGender.Male, new DateTime(1980,06,5), "Slytherin", Side.DeathEaters),
            CreateCharacter("Remus", "Lupin", IsoGender.Male, new DateTime(1960,03,10), "Gryffindor", Side.OoP),
            CreateCharacter("Pansy", "Parkinson", IsoGender.Female, new DateTime(1980,05,02), "Slytherin", Side.NotKnown)
        };
    }
}
