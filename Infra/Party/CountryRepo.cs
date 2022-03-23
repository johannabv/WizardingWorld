using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CountryRepo : Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected override Country ToDomain(CountryData d) => new(d);
    }
}
