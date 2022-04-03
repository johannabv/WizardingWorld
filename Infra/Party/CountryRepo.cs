using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CountryRepo : Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected override Country ToDomain(CountryData d) => new(d); 
        internal override IQueryable<CountryData> AddFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q; 
            return q.Where( 
                x => x.ID.Contains(y)
                || x.Code.Contains(y)
                || x.EnglishName.Contains(y)
                || x.NativeName.Contains(y));
        }
    }
}
