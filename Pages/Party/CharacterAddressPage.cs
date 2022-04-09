using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CharacterAddressPage : PagedPage<CharacterAddressView, CharacterAddress, ICharacterAddressRepo> {
        private readonly ICharacterRepo characters;
        private readonly IPlaceRepo places;
        public CharacterAddressPage(ICharacterAddressRepo r, ICharacterRepo c, IPlaceRepo p) : base(r) {
            characters = c;
            places = p;
        }
        protected override CharacterAddress ToObject(CharacterAddressView? item) => new CharacterAddressViewFactory().Create(item);
        protected override CharacterAddressView ToView(CharacterAddress? entity) => new CharacterAddressViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CharacterAddressView.Name),
            nameof(CharacterAddressView.Code),
            nameof(CharacterAddressView.CharacterID),
            nameof(CharacterAddressView.PlaceID),
            nameof(CharacterAddressView.Description),
        };
        public IEnumerable<SelectListItem> Characters
            => characters?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Places
            => places?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public string CharacterName(string? characterId = null)
            => Characters?.FirstOrDefault(x => x.Value == (characterId ?? string.Empty))?.Text ?? "Unspecified";
        public string PlaceName(string? placeId = null)
            => Places?.FirstOrDefault(x => x.Value == (placeId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, CharacterAddressView v) {
            var r = base.GetValue(name, v);
            return name == nameof(CharacterAddressView.CharacterID) ? CharacterName(r as string)
                : name == nameof(CharacterAddressView.PlaceID) ? PlaceName(r as string)
                : r;
        }
    }
}
