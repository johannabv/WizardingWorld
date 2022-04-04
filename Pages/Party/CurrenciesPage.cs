using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrencyRepo> {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency ToObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView ToView(Currency? entity) => new CurrencyViewFactory().Create(entity);
        public string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Code),
            nameof(CurrencyView.EnglishName),
            nameof(CurrencyView.NativeName)
        };
        public object? GetValue(string name, CurrencyView v)
            => Safe.Run(() => {
                var propertyInfo = v?.GetType()?.GetProperty(name);
                return propertyInfo == null ? null : propertyInfo.GetValue(v);
            }, null);
    }
}
