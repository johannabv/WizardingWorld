﻿using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class SpellsRepo : Repo<Spell, SpellData>, ISpellsRepo {
        public SpellsRepo(WizardingWorldDb? db) : base(db, db?.Spells) { }
        protected internal override Spell ToDomain(SpellData d) => new(d);
        internal override IQueryable<SpellData> AddFilter(IQueryable<SpellData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.Id.Contains(y)
                  || x.SpellName.Contains(y)
                  || x.Type.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
