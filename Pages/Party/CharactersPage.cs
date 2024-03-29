﻿using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CharactersPage : PagedPage<CharacterView, Character, ICharactersRepo> {
        private readonly IHousesRepo houses;
        public CharactersPage(ICharactersRepo r, IHousesRepo c) : base(r) => houses = c;
        protected override Character ToObject(CharacterView? item) => new CharacterViewFactory().Create(item);
        protected override CharacterView ToView(Character? entity) => new CharacterViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CharacterView.FirstName),
            nameof(CharacterView.LastName),
            nameof(CharacterView.Gender),
            nameof(CharacterView.DoB),
            nameof(CharacterView.HogwartsHouse),
            nameof(CharacterView.Organization),
        };
        public override string[] RelatedIndexColumns { get; } = new[] {
            nameof(AddressView.Street),
            nameof(AddressView.City),
            nameof(AddressView.Region),
            nameof(AddressView.CountryId),
            nameof(AddressView.Description)
        };
        public IEnumerable<SelectListItem> Houses
            => houses?.GetAll(x => x.HouseName)?.Select(x => new SelectListItem(x.HouseName, x.HouseName)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Genders
         => Enum.GetValues<IsoGender>()?.Select(x => new SelectListItem(x.GetDescription(), x.ToString())) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Organizations
         => Enum.GetValues<Side>()?.Select(x => new SelectListItem(x.GetDescription(), x.ToString())) ?? new List<SelectListItem>();
        public string OrganizationDescription(Side? x)
            => (x ?? Side.NotKnown).GetDescription(); 
        public string GenderDescription(IsoGender? x)
            => (x ?? IsoGender.NotApplicable).GetDescription();
        public string HouseName(string? houseId = null)
            => Houses?.FirstOrDefault(x => x.Value == (houseId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue<T>(string name, T v) {
            object? r = base.GetValue(name, v);
            if (name == nameof(CharacterView.HogwartsHouse)) return HouseName(r as string);
            if (name == nameof(CharacterView.Gender)) return GenderDescription((IsoGender)r);
            if (name == nameof(CharacterView.Organization)) return OrganizationDescription((Side)r);
            return r;
        }
        public Lazy<List<Address?>> Addresses => ToObject(Item).Addresses;
    }
}
