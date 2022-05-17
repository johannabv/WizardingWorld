using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class WoodsRepo : Repo<Wood, WoodData>, IWoodsRepo {
        public WoodsRepo(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected internal override Wood ToDomain(WoodData d) => new(d);
        internal override IQueryable<WoodData> AddFilter(IQueryable<WoodData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.Name.Contains(y)
                  || x.Traits.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
