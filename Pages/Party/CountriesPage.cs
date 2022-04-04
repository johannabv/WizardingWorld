using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CountriesPage : PagedPage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country ToObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView ToView(Country? entity) => new CountryViewFactory().Create(entity);
        public string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Code),
            nameof(CountryView.EnglishName),
            nameof(CountryView.NativeName)
        };
        public object? GetValue(string name, CountryView v)
            => Safe.Run(() => {
                var propertyInfo = v?.GetType()?.GetProperty(name);
                return propertyInfo == null ? null : propertyInfo.GetValue(v);
            }, null);
    }
}
