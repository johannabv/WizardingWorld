using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData> {
        public CurrenciesInitializer(WizardingWorldDb? db) : base(db, db?.Currencies) { }
        protected override IEnumerable<CurrencyData> GetEntities {
            get {
                List<CurrencyData> l = new();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    RegionInfo c = new(new CultureInfo(cul.Name, false).LCID);
                    string id = c.ISOCurrencySymbol;
                    if (!IsCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue; 
                    CurrencyData d = CreateCurrency(id, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CurrencyData CreateCurrency(string code, string englishName, string nativeName)
            => new() { 
                ID = code ?? BaseData.NewId, 
                Name = englishName, 
                Description=nativeName, 
                Code = code ?? BaseEntity.DefaultStr
            };
    }
}

