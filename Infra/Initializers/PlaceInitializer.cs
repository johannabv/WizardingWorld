using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers {
    public sealed class PlaceInitializer : BaseInitializer<PlaceData> {

        public PlaceInitializer(WizardingWorldDb? db) : base(db, db?.Places) { }
        protected override IEnumerable<PlaceData> GetEntities => new[] {
            CreateAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GBR", "Dursle's home"),
            CreateAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GBR", "Granger's home"),
            CreateAddress("The Burrow", "Ottery St Catchpole", "Devon", "DE17 5BB", "GBR", "Weasley's home"),
            CreateAddress("School of Witchcraft and Wizardry", "Hogwarts", "Hogsmeade", "HO29 9XX", "GBR", "Hogwarts school"),
        };
        internal static PlaceData CreateAddress(string street, string city, string region, string zipCode, string country, string description) {
            var address = new PlaceData {
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
