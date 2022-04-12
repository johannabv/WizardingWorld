using WizardingWorld.Data.Enums;

namespace WizardingWorld.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new()) { }
        public Currency(CurrencyData d) : base(d) { }
        public List<CountryCurrency> CountryCurrencies
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
            .GetAll(x => x.CurrencyID)?
            .Where(x => x.CurrencyID == ID)?
            .ToList() ?? new List<CountryCurrency>();

        public List<Country?> Countries
            => CountryCurrencies
            .Select(x => x.Country)
            .ToList() ?? new List<Country?>();
    }
}
