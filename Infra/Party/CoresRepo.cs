using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CoresRepo : Repo<Core, CoreData>, ICoresRepo {
        public CoresRepo(WizardingWorldDb? db) : base(db, db?.Cores) { }
        protected override Core ToDomain(CoreData d) => new(d);
        internal override IQueryable<CoreData> AddFilter(IQueryable<CoreData> q) {
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
