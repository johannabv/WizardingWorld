using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class HousesInitializer : BaseInitializer<HouseData> {
        public HousesInitializer(WizardingWorldDb? db) : base(db, db?.Houses) { }
        internal static HouseData CreateHouse(string houseName, string headName, string founder, string color, string description) {
            var spell = new HouseData {
                ID = houseName+headName,
                HouseName = houseName,
                FounderName = founder,
                HeadOfHouseName = headName,
                Color = color,
                Description = description
            };
            return spell;
        }
        protected override IEnumerable<HouseData> GetEntities => new[] {
            CreateHouse("Slytherin", "Severus Snape", "Salazar Slytherin", "green", "cunning, ambitious"),
            CreateHouse("Ravenclaw", "", "Helena Ravenclaw", "blue", "smart"),
            CreateHouse("Griffindor", "Minerva Mcgonogall", "", "red", "brave"),
            CreateHouse("Huffelpuff", "", "Helga Huffelpuff", "yellow", "loyal")
        };
    }
}
