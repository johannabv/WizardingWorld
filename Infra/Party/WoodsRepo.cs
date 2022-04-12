using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class WoodsRepo : Repo<Wood, WoodData>, IWoodsRepo {
        public WoodsRepo(WizardingWorldDb? db) : base(db, db?.Woods) { }
        protected override Wood ToDomain(WoodData d) => new(d);
        internal override IQueryable<WoodData> AddFilter(IQueryable<WoodData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.Name.Contains(y)
                  || x.Code.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
