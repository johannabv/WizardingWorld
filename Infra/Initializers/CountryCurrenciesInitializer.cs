using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
        public CountryCurrenciesInitializer(WizardingWorldDb? db) : base(db, db?.CountryCurrencies) { }
        protected override IEnumerable<CountryCurrencyData> GetEntities {
            get {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var countryId = c.ThreeLetterISORegionName;
                    var currencyId = c.ISOCurrencySymbol;
                    var nativeName = c.CurrencyNativeName;
                    var currencyCode = c.CurrencySymbol;
                    var d = CreateEntity(countryId, currencyId, currencyCode, nativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryCurrencyData CreateEntity(string countryId, string currencyId,
            string code, string? name = null, string? description = null)
            => new() {
                ID = BaseData.NewId,
                CurrencyID = currencyId,
                CountryID = countryId,
                Code = code ?? BaseEntity.DefaultStr,
                Name = name,
                Description = description
            };
    }
}