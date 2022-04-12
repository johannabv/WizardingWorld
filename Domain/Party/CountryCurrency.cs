using WizardingWorld.Data.Enums;

namespace WizardingWorld.Domain.Party {
    public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }
    public sealed class CountryCurrency : NamedEntity<CountryCurrencyData> {
        public CountryCurrency() : this(new ()) { }
        public CountryCurrency(CountryCurrencyData d) : base(d) { }
        public string CurrencyID => GetValue(Data?.CurrencyID);
        public string CountryID => GetValue(Data?.CountryID);
        public Country? Country => GetRepo.Instance<ICountriesRepo>().Get(CountryID);
        public Currency? Currency => GetRepo.Instance<ICurrenciesRepo>().Get(CurrencyID);
    }
}
