using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class WandsRepo : Repo<Wand, WandData>, IWandsRepo {
        public WandsRepo(WizardingWorldDb? db) : base(db, db?.Wands) { }
        protected internal override Wand ToDomain(WandData d) => new(d);
        internal override IQueryable<WandData> AddFilter(IQueryable<WandData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.CoreID.Contains(y)
                  || x.Info.Contains(y)
                  || x.WoodID.Contains(y)
            );
        }
    }
}
