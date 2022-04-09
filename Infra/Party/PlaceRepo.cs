using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class PlaceRepo : Repo<Place, PlaceData>, IPlaceRepo {
        public PlaceRepo(WizardingWorldDb? db) : base(db, db?.Places) { }
        protected override Place ToDomain(PlaceData d) => new(d);
        internal override IQueryable<PlaceData> AddFilter(IQueryable<PlaceData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Street.Contains(y)
                || x.CountryId.Contains(y)
                || x.ID.Contains(y)
                || x.City.Contains(y)
                || x.Region.Contains(y)
                || x.Description.Contains(y)
                || x.ZipCode.Contains(y));
        }
    }
}
