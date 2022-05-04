using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class CharactersRepo : Repo<Character, CharacterData>, ICharactersRepo {
        public CharactersRepo(WizardingWorldDb? db) : base(db, db?.Characters) { }
        protected internal override Character ToDomain(CharacterData d) => new(d);
        internal override IQueryable<CharacterData> AddFilter(IQueryable<CharacterData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => x.ID.Contains(y)
                  || x.FirstName.Contains(y)
                  || x.LastName.Contains(y)
                  || x.Organisation.ToString().Contains(y)
                  || x.HogwartsHouse.Contains(y)
                  || x.Gender.ToString().Contains(y)
                  || x.DoB.ToString().Contains(y)
            );
        }
    }
}
