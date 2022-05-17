using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CoreMaterialsInitializer : BaseInitializer<CoreMaterialData> {
        public CoreMaterialsInitializer(WizardingWorldDb? db) : base(db, db?.Cores) { }
        protected override IEnumerable<CoreMaterialData> GetEntities {
            get {
                List<CoreMaterialData> l = new List<CoreMaterialData>();
                string filePath = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_core.txt";
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) l.Add(CreateCore(line.Split(':')[0], line.Split(':')[1]));
                    reader.Close();
                }
                return l;
            }
        }
        internal static CoreMaterialData CreateCore(string name, string description)
            => new() {
                ID = name,
                Name = name,
                Code = BaseEntity.DefaultStr,
                Description = description
            };
    }
}
