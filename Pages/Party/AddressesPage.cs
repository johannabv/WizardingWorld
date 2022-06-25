using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class AddressesPage : PagedPage<AddressView, Address, IAddressRepo> {
        private readonly ICountriesRepo countries;
        public AddressesPage(IAddressRepo r, ICountriesRepo c) : base(r) => countries = c;
        protected override Address ToObject(AddressView? item) => new AddressViewFactory().Create(item);
        protected override AddressView ToView(Address? entity) => new AddressViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(AddressView.Street),
            nameof(AddressView.City),
            nameof(AddressView.Region),
            nameof(AddressView.ZipCode),
            nameof(AddressView.CountryId),
            nameof(AddressView.Description),
        };
        public override string[] RelatedIndexColumns { get; } = new[] {
            nameof(CharacterView.FirstName),
            nameof(CharacterView.LastName),
            nameof(CharacterView.Gender),
            nameof(CharacterView.DoB),
            nameof(CharacterView.HogwartsHouse),
            nameof(CharacterView.Organization),
        };

        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.Id))
            ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue<T>(string name, T v) {
            object? r = base.GetValue<T>(name, v);
            return name == nameof(AddressView.CountryId) ? CountryName(r as string) : r;
        }

        public Lazy<List<Character?>> Characters => ToObject(Item).Characters;
    }
}
