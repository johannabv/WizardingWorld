using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo {
        public CountriesRepo(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected internal override Country ToDomain(CountryData d) => new(d); 
        internal override IQueryable<CountryData> AddFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.Code.Contains(y)
                  || x.Description.Contains(y)
                  || x.ID.Contains(y)
                  || x.Name.Contains(y)
            );
        }
    }
}
