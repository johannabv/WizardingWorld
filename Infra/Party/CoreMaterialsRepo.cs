using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class CoreMaterialsRepo : Repo<CoreMaterial, CoreMaterialData>, ICoreMaterialsRepo {
        public CoreMaterialsRepo(WizardingWorldDb? db) : base(db, db?.Cores) { }
        protected internal override CoreMaterial ToDomain(CoreMaterialData d) => new(d);
        internal override IQueryable<CoreMaterialData> AddFilter(IQueryable<CoreMaterialData> q) {
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
