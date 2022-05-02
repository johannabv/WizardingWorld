using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using System.Text;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CoresInitializer : BaseInitializer<CoreData> {
        public CoresInitializer(WizardingWorldDb? db) : base(db, db?.Cores) { }
        protected override IEnumerable<CoreData> GetEntities {
            get {
                var l = new List<CoreData>();
                var filePath = "C:/Users/johan/source/repos/WizardingWorld/WizardingWorld/wand_core.txt";
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new(stream, Encoding.UTF8)) {
                    string? line = string.Empty;
                    while ((line = reader.ReadLine()) != null) l.Add(CreateCore(line.Split(':')[0], line.Split(':')[1]));
                    reader.Close();
                }
                return l;
            }
        }
        internal static CoreData CreateCore(string name, string description)
            => new() {
                ID = name,
                Name = name,
                Code = BaseEntity.DefaultStr,
                Description = description
            };
    }
}
