using Microsoft.AspNetCore.Authorization;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class CountriesPage : PagedPage<CountryView, Country, ICountriesRepo> {
        public CountriesPage(ICountriesRepo r) : base(r) { }
        protected override Country ToObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView ToView(Country? entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Code),
            nameof(CountryView.Name),
            nameof(CountryView.Description)
        };

        public List<Currency?> Currencies => ToObject(Item).Currencies;
    }
}
