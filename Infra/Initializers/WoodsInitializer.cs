using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.IO;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class WoodsInitializer : BaseInitializer<WoodData> {
        public WoodsInitializer(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected override IEnumerable<WoodData> GetEntities {
            get {
                var l = new List<WoodData>();
                var filePath = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_wood.txt";
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) l.Add(CreateWood(line.Split(':')[0], line.Split(':')[1]));
                    reader.Close();
                }
                return l;
            }
        }
        internal static WoodData CreateWood(string name, string description)
            => new() {
                ID = BaseData.NewId,
                Name = name,
                Code = BaseEntity.DefaultStr,
                Description = description
            };
    }
}
