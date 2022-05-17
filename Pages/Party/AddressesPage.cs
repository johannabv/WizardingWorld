using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
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
            nameof(AddressView.CountryID),
            nameof(AddressView.Description),
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, AddressView v) {
            object? r = base.GetValue(name, v);
            return name == nameof(AddressView.CountryID) ? CountryName(r as string) : r;
        }
        public Lazy<List<Character?>> Characters => ToObject(Item).Characters;
    }
}
