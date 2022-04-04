using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class HousesPage : PagedPage<HouseView, House, IHouseRepo> {
        public HousesPage(IHouseRepo r) : base(r) { }
        protected override House ToObject(HouseView? item) => new HouseViewFactory().Create(item);
        protected override HouseView ToView(House? entity) => new HouseViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(HouseView.HouseName),
            nameof(HouseView.FounderName),
            nameof(HouseView.HeadOfHouseName),
            nameof(HouseView.Color),
            nameof(HouseView.Description)
        };
    }
}
