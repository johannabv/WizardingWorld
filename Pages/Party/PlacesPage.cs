using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class PlacesPage : PagedPage<PlaceView, Place, IPlaceRepo> {
        private readonly ICountryRepo countries;
        public PlacesPage(IPlaceRepo r, ICountryRepo c) : base(r) => countries = c;
        protected override Place ToObject(PlaceView? item) => new PlaceViewFactory().Create(item);
        protected override PlaceView ToView(Place? entity) => new PlaceViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PlaceView.Street),
            nameof(PlaceView.City),
            nameof(PlaceView.Region),
            nameof(PlaceView.ZipCode),
            nameof(PlaceView.CountryId),
            nameof(PlaceView.Description),
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, PlaceView v) {
            var r = base.GetValue(name, v);
            return name == nameof(PlaceView.CountryId) ? CountryName(r as string) : r;
        }
    }
}
