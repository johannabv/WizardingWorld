using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class CharactersPage : BasePage<CharacterView,Character,ICharacterRepo> {
        public CharactersPage(ICharacterRepo r) : base(r) { }
        protected override Character toObject(CharacterView item) => new CharacterViewFactory().Create(item);
        protected override CharacterView toView(Character entity) => new CharacterViewFactory().Create(entity);
    }
}
