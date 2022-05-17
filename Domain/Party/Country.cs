using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new()) { }
        public Country(CountryData d) : base(d) { }
        
        public Lazy<List<CountryCurrency>> CountryCurrencies {
            get {
                List<CountryCurrency> l = GetRepo.Instance<ICountryCurrenciesRepo>()?
                      .GetAll(x => x.CountryID)?
                      .Where(x => x.CountryID == ID)?
                      .ToList() ?? new List<CountryCurrency>();
                return new Lazy<List<CountryCurrency>>(l);
            }
        }
        public Lazy<List<Currency?>> Currencies {
            get {
                List<Currency?> l = CountryCurrencies
                    .Value
                    .Select(x => x.Currency)
                    .ToList() ?? new List<Currency?>();
                return new Lazy<List<Currency?>>(l);
            }
        }
    }
}
