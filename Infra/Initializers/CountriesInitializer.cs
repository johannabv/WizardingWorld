using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CountriesInitializer : BaseInitializer<CountryData> {
        public CountriesInitializer(WizardingWorldDb db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> GetEntities {
            get {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var d = CreateCountry(c.EnglishName, c.ThreeLetterISORegionName);
                    if (l.FirstOrDefault(x => x.ID == d.ID) is not null) continue;
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryData CreateCountry(string name, string code) => new() { ID = name + code, Name = name, Code = code };
    }
}
