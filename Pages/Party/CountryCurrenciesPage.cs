using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo> {
        private readonly ICountriesRepo countries;
        private readonly ICurrenciesRepo currencies;
        public CountryCurrenciesPage(ICountryCurrenciesRepo r, ICountriesRepo country, ICurrenciesRepo currency) : base(r) {
            countries = country;
            currencies = currency;
        }
        protected override CountryCurrency ToObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);
        protected override CountryCurrencyView ToView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryCurrencyView.Name),
            nameof(CountryCurrencyView.Code),
            nameof(CountryCurrencyView.CountryID),
            nameof(CountryCurrencyView.CurrencyID),
            nameof(CountryCurrencyView.Description),
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Currencies
            => currencies?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";
        public string CurrencyName(string? currencyId = null)
            => Currencies?.FirstOrDefault(x => x.Value == (currencyId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, CountryCurrencyView v) {
            object? r = base.GetValue(name, v);
            return name == nameof(CountryCurrencyView.CountryID) ? CountryName(r as string)
                : name == nameof(CountryCurrencyView.CurrencyID) ? CurrencyName(r as string)
                : r;
        }
    }
}
