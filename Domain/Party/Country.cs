using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountryRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
    }
}
