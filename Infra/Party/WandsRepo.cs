using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class WandsRepo : Repo<Wand, WandData>, IWandsRepo {
        public WandsRepo(WizardingWorldDb? db) : base(db, db?.Wands) { }
        protected internal override Wand ToDomain(WandData d) => new(d);
        internal override IQueryable<WandData> AddFilter(IQueryable<WandData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.Id.Contains(y)
                  || x.CoreId.Contains(y)
                  || x.Info.Contains(y)
                  || x.WoodId.Contains(y)
            );
        }
    }
}
