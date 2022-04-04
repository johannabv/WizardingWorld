using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class SpellRepo : Repo<Spell, SpellData>, ISpellRepo {
        public SpellRepo(WizardingWorldDb? db) : base(db, db?.Spells) { }
        protected override Spell ToDomain(SpellData d) => new(d);
        internal override IQueryable<SpellData> AddFilter(IQueryable<SpellData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => DoesContain(x.ID, y)
                || DoesContain(x.SpellName, y)
                || DoesContain(x.Type, y)
                || DoesContain(x.Description, y)
            );
        }
    }
}
