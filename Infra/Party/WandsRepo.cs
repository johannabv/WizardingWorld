﻿using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class WandsRepo : Repo<Wand, WandData>, IWandsRepo {
        public WandsRepo(WizardingWorldDb? db) : base(db, db?.Wands) { }
        protected override Wand ToDomain(WandData d) => new(d);
        internal override IQueryable<WandData> AddFilter(IQueryable<WandData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.Core.Contains(y)
                  || x.Info.Contains(y)
                  || x.Wood.Contains(y)
            );
        }
    }
}