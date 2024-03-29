﻿using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class CharactersRepo : Repo<Character, CharacterData>, ICharactersRepo {
        public CharactersRepo(WizardingWorldDb? db) : base(db, db?.Characters) { }
        protected internal override Character ToDomain(CharacterData d) => new(d);
        internal override IQueryable<CharacterData> AddFilter(IQueryable<CharacterData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.Id.Contains(y)
                  || x.FirstName.Contains(y)
                  || x.LastName.Contains(y)
                  || x.Organization.ToString().Contains(y)
                  || x.HogwartsHouse.Contains(y)
                  || x.Gender.ToString().Contains(y)
                  || x.DoB.ToString().Contains(y)
            );
        }
    }
}
