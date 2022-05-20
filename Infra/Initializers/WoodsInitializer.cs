using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class WoodsInitializer : BaseInitializer<WoodData> {
        public WoodsInitializer(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected override IEnumerable<WoodData> GetEntities {
            get {
                List<WoodData> l = new();
                string filePath = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_wood.txt";
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) {
                        string one = line.Split(':')[0] ?? "undefined";
                        string two = line.Split(':')[1] ?? "undefined";
                        string three = line.Split(':')[2] ?? "undefined";
                        l.Add(CreateWood(one,two,three));
                    }
                    reader.Close();
                }
                return l;
            }
        }
        internal static WoodData CreateWood(string name, string traits, string description)
            => new() {
                ID = name,
                Name = name,
                Traits = traits,
                Description = description
            };
    }
}
