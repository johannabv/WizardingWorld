using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData> {
        public CurrenciesInitializer(WizardingWorldDb? db) : base(db, db?.Currencies) { }
        protected override IEnumerable<CurrencyData> GetEntities {
            get {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ISOCurrencySymbol;
                    if (!IsCorrectId(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue; 
                    var d = CreateCurrency(id, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static bool IsCorrectId(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
        internal static CurrencyData CreateCurrency(string code, string englishName, string nativeName)
            => new() { ID = code ?? EntityData.NewId, EnglishName = englishName, NativeName=nativeName, Code = code ?? BaseEntity.DefaultStr};
    }
}

