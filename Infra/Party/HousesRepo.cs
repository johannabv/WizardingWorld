using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class HousesRepo : Repo<House, HouseData>, IHousesRepo {
        public HousesRepo(WizardingWorldDb? db) : base(db, db?.Houses) { }
        protected internal override House ToDomain(HouseData d) => new(d);
        internal override IQueryable<HouseData> AddFilter(IQueryable<HouseData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.HouseName.Contains(y)
                  || x.HeadOfHouseName.Contains(y)
                  || x.FounderName.Contains(y)
                  || x.Color.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
