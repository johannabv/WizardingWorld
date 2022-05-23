using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class CoreMaterialsPage : PagedPage<CoreMaterialView, CoreMaterial, ICoreMaterialsRepo> {
        public CoreMaterialsPage(ICoreMaterialsRepo r) : base(r) { }
        protected override CoreMaterial ToObject(CoreMaterialView? item) => new CoreMaterialViewFactory().Create(item);
        protected override CoreMaterialView ToView(CoreMaterial? entity) => new CoreMaterialViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CoreMaterialView.Name),
            nameof(CoreMaterialView.Description)
        };
    }
}
