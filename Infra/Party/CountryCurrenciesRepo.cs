using WizardingWorld.Data.Enums;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo {
        public CountryCurrenciesRepo(WizardingWorldDb? db) : base(db, db?.CountryCurrencies) { }
        protected override CountryCurrency ToDomain(CountryCurrencyData d) => new(d);
        internal override IQueryable<CountryCurrencyData> AddFilter(IQueryable<CountryCurrencyData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Code.Contains(y)
                  || x.CountryID.Contains(y)
                  || x.CurrencyID.Contains(y)
                  || x.ID.Contains(y)
                  || x.Name.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
