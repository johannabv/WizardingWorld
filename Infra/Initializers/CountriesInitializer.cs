using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CountriesInitializer : BaseInitializer<CountryData> {
        public CountriesInitializer(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> GetEntities {
            get {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ThreeLetterISORegionName;
                    if (!IsCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue;
                    var d = CreateCountry(id, c.EnglishName, c.NativeName);
                    l.Add(d);
                }
                return l;
            }
        } 
        internal static CountryData CreateCountry(string code, string name, string description) 
            => new() { 
                ID = code ?? BaseData.NewId, 
                Name = name, 
                Code = code ?? BaseEntity.DefaultStr, 
                Description = description
            };
    }
}
