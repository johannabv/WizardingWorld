using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CharactersPage : PagedPage<CharacterView, Character, ICharacterRepo> {
        public CharactersPage(ICharacterRepo r) : base(r) { }
        protected override Character ToObject(CharacterView? item) => new CharacterViewFactory().Create(item);
        protected override CharacterView ToView(Character? entity) => new CharacterViewFactory().Create(entity);
        public string[] IndexColumns { get; } = new[] {
            nameof(CharacterView.FirstName),
            nameof(CharacterView.LastName),
            nameof(CharacterView.Gender),
            nameof(CharacterView.DoB),
            nameof(CharacterView.HogwartsHouse),
            nameof(CharacterView.Organisation),
        };
        public object? GetValue(string name, CharacterView v)
            => Safe.Run(() => {
                var propertyInfo = v?.GetType()?.GetProperty(name);
                return propertyInfo == null ? null : propertyInfo.GetValue(v);
            }, null);
    }
}
