using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
        public CurrenciesRepo(WizardingWorldDb? db) : base(db, db?.Currencies) { }
        protected override Currency ToDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> AddFilter(IQueryable<CurrencyData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.Code.Contains(y)
                  || x.Description.Contains(y)
                  || x.ID.Contains(y)
                  || x.Name.Contains(y)
            );
        }
    }
}
