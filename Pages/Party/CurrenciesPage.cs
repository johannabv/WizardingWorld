using Microsoft.AspNetCore.Authorization;
using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrenciesRepo> {
        public CurrenciesPage(ICurrenciesRepo r) : base(r) { }
        protected override Currency ToObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView ToView(Currency? entity) => new CurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Code),
            nameof(CurrencyView.Name),
            nameof(CurrencyView.Description)
        };
        public Lazy<List<Country?>> Countries => ToObject(Item).Countries;
    }
}
