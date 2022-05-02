using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class WoodsInitializer : BaseInitializer<WoodData> {
        public WoodsInitializer(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected override IEnumerable<WoodData> GetEntities {
            get {
                var l = new List<WoodData>();
                var filePathA = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_wood.txt";
                var filePathInProject = @"source/repos/WizardingWorld/WizardingWorld/wand_wood.txt";
                var projectDirectory = System.IO.Path.GetFullPath(@"../../../../");
                var filePathB = Path.Combine(projectDirectory, filePathInProject);
                var stream = new FileStream(filePathA, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) {
                        var one = line.Split(':')[0] ?? "undefined";
                        var two = line.Split(':')[1] ?? "undefined";
                        var three = line.Split(':')[2] ?? "undefined";
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
