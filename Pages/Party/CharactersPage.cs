using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CharactersPage : PagedPage<CharacterView, Character, ICharacterRepo> {
        private readonly IHouseRepo houses;
        public CharactersPage(ICharacterRepo r, IHouseRepo c) : base(r) => houses = c;
        protected override Character ToObject(CharacterView? item) => new CharacterViewFactory().Create(item);
        protected override CharacterView ToView(Character? entity) => new CharacterViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CharacterView.FirstName),
            nameof(CharacterView.LastName),
            nameof(CharacterView.Gender),
            nameof(CharacterView.DoB),
            nameof(CharacterView.HogwartsHouse),
            nameof(CharacterView.Organisation),
        };
        public IEnumerable<SelectListItem> Houses 
            => houses?.GetAll(x => x.HouseName)?.Select(x => new SelectListItem(x.HouseName, x.HouseName)) ?? new List<SelectListItem>();
        public string HouseName(string? houseId = null) 
            => Houses?.FirstOrDefault(x => x.Value == (houseId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, CharacterView v) {
            var r = base.GetValue(name, v);
            if(name ==nameof(CharacterView.HogwartsHouse)) return HouseName(r as string);
            return r;
        }
    }
}
