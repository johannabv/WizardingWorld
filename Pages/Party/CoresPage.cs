using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CoresPage : PagedPage<CoreView, Core, ICoresRepo> {
        public CoresPage(ICoresRepo r) : base(r) { }
        protected override Core ToObject(CoreView? item) => new CoreViewFactory().Create(item);
        protected override CoreView ToView(Core? entity) => new CoreViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CoreView.Name),
            nameof(CoreView.Description)
        };
    }
}
