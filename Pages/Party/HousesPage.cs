﻿using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class HousesPage : PagedPage<HouseView, House, IHousesRepo> {
        public HousesPage(IHousesRepo r) : base(r) { }
        protected override House ToObject(HouseView? item) => new HouseViewFactory().Create(item);
        protected override HouseView ToView(House? entity) => new HouseViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(HouseView.HouseName),
            nameof(HouseView.FounderName),
            nameof(HouseView.HeadOfHouseName),
            nameof(HouseView.Color),
            nameof(HouseView.Description)
        };
        public override string[] RelatedIndexColumns { get; } = new[] {
            nameof(CharacterView.FirstName),
            nameof(CharacterView.LastName),
            nameof(CharacterView.Gender),
            nameof(CharacterView.DoB),
            nameof(CharacterView.HogwartsHouse),
            nameof(CharacterView.Organization),
        };
        public Lazy<List<Character>> Characters => ToObject(Item).Characters;
    }
}
