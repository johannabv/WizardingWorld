using Microsoft.AspNetCore.Authorization;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class WoodsPage : PagedPage<WoodView, Wood, IWoodsRepo> {
        public WoodsPage(IWoodsRepo r) : base(r) { }
        protected override Wood ToObject(WoodView? item) => new WoodViewFactory().Create(item);
        protected override WoodView ToView(Wood? entity) => new WoodViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(WoodView.Name),
            nameof(WoodView.Traits),
            nameof(WoodView.Description)
        };
    }
}
