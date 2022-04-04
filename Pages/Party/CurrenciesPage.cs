using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrencyRepo> {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency ToObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView ToView(Currency? entity) => new CurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Code),
            nameof(CurrencyView.EnglishName),
            nameof(CurrencyView.NativeName)
        };
    }
}
