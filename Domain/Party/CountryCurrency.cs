using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountryCurrencyRepo : IRepo<CountryCurrency> { }
    public sealed class CountryCurrency : NamedEntity<CountryCurrencyData> {
        public CountryCurrency() : this(new ()) { }
        public CountryCurrency(CountryCurrencyData d) : base(d) { }
        public string CurrencyID => GetValue(Data?.CurrencyID);
        public string CountryID => GetValue(Data?.CountryID);
    }
}
