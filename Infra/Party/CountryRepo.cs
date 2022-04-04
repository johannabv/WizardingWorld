using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CountryRepo : Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected override Country ToDomain(CountryData d) => new(d); 
        internal override IQueryable<CountryData> AddFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => DoesContain(x.ID, y)
                || DoesContain(x.Code, y)
                || DoesContain(x.EnglishName, y)
                || DoesContain(x.NativeName, y)
            );
        }
    }
}
