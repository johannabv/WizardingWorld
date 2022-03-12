using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CharacterRepo : Repo<Character, CharacterData>, ICharacterRepo {
        public CharacterRepo(WizardingWorldDb db) : base(db, db.Characters) { }
        protected override Character toDomain(CharacterData d) => new(d);
    }
}
