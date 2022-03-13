using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class CharactersPage : BasePage<CharacterView,Character,ICharacterRepo> {
        public CharactersPage(ICharacterRepo r) : base(r) { }
        protected override Character ToObject(CharacterView? item) => new CharacterViewFactory().Create(item);
        protected override CharacterView ToView(Character? entity) => new CharacterViewFactory().Create(entity);
    }
}
