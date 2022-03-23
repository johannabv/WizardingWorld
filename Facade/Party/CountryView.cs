using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
        protected override Country ToEntity(CountryData d) => new(d);
        public override CountryView Create(Country? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    public sealed class CountryView : BaseView {
        [DisplayName("Currency"), Required] public string? Name { get; set; }
        [DisplayName("Code"), Required] public string? Code { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
