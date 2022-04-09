using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CountriesPage : PagedPage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country ToObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView ToView(Country? entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Code),
            nameof(CountryView.Name),
            nameof(CountryView.Description)
        };
    }
}
