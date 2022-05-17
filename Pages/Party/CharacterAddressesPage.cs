using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class CharacterAddressesPage : PagedPage<CharacterAddressView, CharacterAddress, ICharacterAddressesRepo> {
        private readonly ICharactersRepo characters;
        private readonly IAddressRepo addresses;
        public CharacterAddressesPage(ICharacterAddressesRepo r, ICharactersRepo c, IAddressRepo p) : base(r) {
            characters = c;
            addresses = p;
        }
        protected override CharacterAddress ToObject(CharacterAddressView? item) => new CharacterAddressViewFactory().Create(item);
        protected override CharacterAddressView ToView(CharacterAddress? entity) => new CharacterAddressViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CharacterAddressView.UseFor),
            nameof(CharacterAddressView.CharacterID),
            nameof(CharacterAddressView.AddressID),
        };
        public IEnumerable<SelectListItem> Characters
            => characters?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Addresses
            => addresses?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> UseFors
         => Enum.GetValues<AddressUse>()?
            .Select(x => new SelectListItem(x.Description(), x.ToString()))
            ?? new List<SelectListItem>();
        public string UseForDescription(AddressUse? x)
            => (x ?? AddressUse.NotKnown).Description();
        public string CharacterName(string? characterId = null)
            => Characters?.FirstOrDefault(x => x.Value == (characterId ?? string.Empty))?.Text ?? "Unspecified";
        public string AddressName(string? addressId = null)
            => Addresses?.FirstOrDefault(x => x.Value == (addressId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, CharacterAddressView v) {
            var r = base.GetValue(name, v);
            return name == nameof(CharacterAddressView.CharacterID) ? CharacterName(r as string)
                : name == nameof(CharacterAddressView.AddressID) ? AddressName(r as string)
                : name == nameof(CharacterAddressView.UseFor) ? UseForDescription((AddressUse) r)
                : r;
        }
    }
}
