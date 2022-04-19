using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new()) { }
        public Country(CountryData d) : base(d) { }
        public List<CountryCurrency> CountryCurrencies
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
            .GetAll(x => x.CountryID)?
            .Where(x => x.CountryID == ID)?
            .ToList() ?? new List<CountryCurrency>();

        public List<Currency?> Currencies
            => CountryCurrencies
            .Select(x => x.Currency)
            .ToList() ?? new List<Currency?>();
    }
}
