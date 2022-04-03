using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CharacterRepo : Repo<Character, CharacterData>, ICharacterRepo {
        public CharacterRepo(WizardingWorldDb? db) : base(db, db?.Characters) { }
        protected override Character ToDomain(CharacterData d) => new(d);
        internal override IQueryable<CharacterData> AddFilter(IQueryable<CharacterData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.ID.Contains(y)
                || x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.Organisation.Contains(y)
                || x.HogwartsHouse.Contains(y)
                || x.Gender.ToString().Contains(y)
                || x.DoB.ToString().Contains(y)
            );
        }
    }
}
