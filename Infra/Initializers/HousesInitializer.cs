using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class HousesInitializer : BaseInitializer<HouseData> {
        public HousesInitializer(WizardingWorldDb? db) : base(db, db?.Houses) { }
        internal static HouseData CreateHouse(string houseName, string headName, string founder, string color, string description) {
            HouseData spell = new() {
                Id = houseName+headName,
                HouseName = houseName,
                FounderName = founder,
                HeadOfHouseName = headName,
                Color = color,
                Description = description
            };
            return spell;
        }
        protected override IEnumerable<HouseData> GetEntities => new[] {
            CreateHouse("Slytherin", "Severus Snape", "Salazar Slytherin", "green and silver", "cunning, ambition, resourcefulness, determination, pride, self-preservation"),
            CreateHouse("Ravenclaw", "Filius Flitwick", "Rowena Ravenclaw", "blue and bronze", "wit, learning, wisdom, acceptance, intelligence, creativity"),
            CreateHouse("Gryffindor", "Minerva Mcgonogall", "Godric Gryffindor", "scarlet and gold", "bravery, courage, determination, daring, nerve, chivalry"),
            CreateHouse("Huffelpuff", "Pomona Sprout", "Helga Huffelpuff", "yellow and black", "loyalty, hard-working, patience, fairness, just, modesty")
        };
    }
}
