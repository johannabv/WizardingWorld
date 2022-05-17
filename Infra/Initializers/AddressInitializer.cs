using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class AddressInitializer : BaseInitializer<AddressData> {

        public AddressInitializer(WizardingWorldDb? db) : base(db, db?.Addresses) { }
        protected override IEnumerable<AddressData> GetEntities => new[] {
            CreateAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GBR", "Dursle's home"),
            CreateAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GBR", "Granger's home"),
            CreateAddress("The Burrow", "Ottery St Catchpole", "Devon", "DE17 5BB", "GBR", "Weasley's home"),
            CreateAddress("School of Witchcraft and Wizardry", "Hogwarts", "Hogsmeade", "HO29 9XX", "GBR", "Hogwarts school"),
        };
        internal static AddressData CreateAddress(string street, string city, string region, string zipCode, string country, string description) {
            AddressData address = new AddressData {
                ID = street,
                Street = street,
                City = city,
                Region = region,
                ZipCode = zipCode,
                CountryID = country,
                Description = description
            };
            return address;
        }
    }
}
