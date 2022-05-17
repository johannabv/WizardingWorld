using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new()) { }
        public Currency(CurrencyData d) : base(d) { }

        public Lazy<List<CountryCurrency>> CountryCurrencies {
            get {
                List<CountryCurrency> l = GetRepo.Instance<ICountryCurrenciesRepo>()?
                      .GetAll(x => x.CurrencyID)?
                      .Where(x => x.CurrencyID == ID)?
                      .ToList() ?? new List<CountryCurrency>();
                return new Lazy<List<CountryCurrency>>(l);
            }
        }
        public Lazy<List<Country?>> Countries {
            get {
                List<Country?> l = CountryCurrencies
                    .Value
                    .Select(x => x.Country)
                    .ToList() ?? new List<Country?>();
                return new Lazy<List<Country?>>(l);
            }
        }
    }
}
