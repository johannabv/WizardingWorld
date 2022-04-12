using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class WoodsInitializer : BaseInitializer<WoodData> {
        public WoodsInitializer(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected override IEnumerable<WoodData> GetEntities {
            get {
                var l = new List<WoodData>();
                
                    FileInfo fi = new FileInfo(@"D:\wand_wood.txt");
                    FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                    using (StreamReader reader = new StreamReader(fs)) {
                        string line;
                        while ((line = reader.ReadLine()) != null) l.Add(CreateWood(line.Split(':')[0], line.Split(':')[1]));
                        reader.Close();
                    } 
                    fs.Close();
                
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
