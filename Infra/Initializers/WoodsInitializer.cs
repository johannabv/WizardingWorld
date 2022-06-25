using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class WoodsInitializer : BaseInitializer<WoodData> {
        public WoodsInitializer(WizardingWorldDb? db) : base(db, db?.Woods) { }
        private string defaultString = "undefined";

        protected override IEnumerable<WoodData> GetEntities {
            get {
                List<WoodData> l = new();
                string filePath = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_wood.txt";
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) {
                        string one = line.Split(':')[0] ?? defaultString;
                        string two = line.Split(':')[1] ?? defaultString;
                        string three = line.Split(':')[2] ?? defaultString;
                        l.Add(CreateWood(one,two,three));
                    }
                    reader.Close();
                }
                return l;
            }
        }
        internal static WoodData CreateWood(string name, string traits, string description)
            => new() {
                Id = name,
                Name = name,
                Traits = traits,
                Description = description
            };
    }
}
