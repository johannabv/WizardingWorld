using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class CountriesPage : BasePage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country ToObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView ToView(Country? entity) => new CountryViewFactory().Create(entity);
    }
}
