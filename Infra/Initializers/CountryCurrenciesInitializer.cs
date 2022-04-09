using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
        public CountryCurrenciesInitializer(WizardingWorldDb? db) : base(db, db?.CountryCurrencies) { }
        internal static CountryCurrencyData CreateEntity(string countryId, string currencyId, string code, string? name = null, string? description = null) {
            var obj = new CountryCurrencyData {
                ID = BaseData.NewId,
                CountryID = countryId,
                CurrencyID = currencyId,
                Name = name,
                Code = code ?? BaseEntity.DefaultStr,
                Description = description
            };
            return obj;
        }
        protected override IEnumerable<CountryCurrencyData> GetEntities {
            get {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var countryId = c.ThreeLetterISORegionName;
                    var currencyId = c.ISOCurrencySymbol;
                    var nativeName = c.NativeName;
                    var currencyCode = c.CurrencySymbol;
                    var d = CreateEntity(countryId, currencyId, nativeName, currencyCode, null);
                    l.Add(d);
                }
                return l;
            }
        }
    }
}