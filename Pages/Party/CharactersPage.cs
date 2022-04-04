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
        public IEnumerable<SelectListItem> Houses { 
            get {
                IEnumerable<SelectListItem> r = new List<SelectListItem>();
                if (houses is null) return r;
                var pageSize = houses.PageSize;
                r = houses.Get().Select(x => new SelectListItem(x.HouseName, x.HouseName));
                houses.PageSize = pageSize;
                return r;
            }
        }
        public string HouseName(string houseId) => Houses?.FirstOrDefault(x => x.Value == houseId)?.Text ?? "Unspecified";
    }
}
