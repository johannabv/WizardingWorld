using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country ToEntity(CountryData d) => new(d); 
    }
    public sealed class CountryView : IsoNamedView { }
}
