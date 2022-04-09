using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountryRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }

        public List<CountryCurrency> CountryCurrencies 
            => GetRepo.Instance<ICountryCurrencyRepo>()?
            .GetAll(x => x.CountryID)?
            .Where(x => x.CountryID == ID)?
            .ToList() ?? new List<CountryCurrency>();
        public List<Currency?> Currencies => CountryCurrencies.Select(x => x.Currency).ToList() ?? new List<Currency?>();
    }
}
