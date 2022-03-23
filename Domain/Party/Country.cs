using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICountryRepo : IRepo<Country> { }
    public sealed class Country : Entity<CountryData> {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
        public string Name => GetValue(Data?.Name);
        public string Code => GetValue(Data?.Code);
        public override string ToString() => $"{Name} ({Code})";
    }
}
