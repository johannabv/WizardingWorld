using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CharacterRepo : Repo<Character, CharacterData>, ICharacterRepo {
        public CharacterRepo(WizardingWorldDb? db) : base(db, db?.Characters) { }
        protected override Character ToDomain(CharacterData d) => new(d);
        internal override IQueryable<CharacterData> AddFilter(IQueryable<CharacterData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => DoesContain(x.ID, y)
                || DoesContain(x.FirstName, y)
                || DoesContain(x.LastName, y)
                || DoesContain(x.Organisation, y)
                || DoesContain(x.HogwartsHouse, y)
                || DoesContain(x.Gender.ToString(), y)
                || DoesContain(x.DoB.ToString(), y)
            );
        }
    }
}
