using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class WoodsPage : PagedPage<WoodView, Wood, IWoodsRepo> {
        public WoodsPage(IWoodsRepo r) : base(r) { }
        protected override Wood ToObject(WoodView? item) => new WoodViewFactory().Create(item);
        protected override WoodView ToView(Wood? entity) => new WoodViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(WoodView.Name),
            nameof(WoodView.Description)
        };
    }
}
