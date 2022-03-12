using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class SpellRepo : Repo<Spell, SpellData>, ISpellRepo {
        public SpellRepo(WizardingWorldDb? db) : base(db, db?.Spells) { }
        protected override Spell toDomain(SpellData d) => new(d);
    }
}
