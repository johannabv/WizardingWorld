using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData> {
        public Country() : this(new()) { }
        public Country(CountryData d) : base(d) { }
    }
}
