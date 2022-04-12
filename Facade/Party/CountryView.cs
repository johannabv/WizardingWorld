using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Enums;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country ToEntity(CountryData d) => new(d); 
    }
    public sealed class CountryView : IsoNamedView { }
}
