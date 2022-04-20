using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class WandsPage : PagedPage<WandView, Wand, IWandsRepo> {
        private readonly IWoodsRepo woods;
        private readonly ICoresRepo cores;
        public WandsPage(IWandsRepo r, ICoresRepo c, IWoodsRepo w) : base(r) {
            woods = w;
            cores = c;
        }
        protected override Wand ToObject(WandView? item) => new WandViewFactory().Create(item);
        protected override WandView ToView(Wand? entity) => new WandViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(WandView.Info),
            nameof(WandView.Core),
            nameof(WandView.Wood)
        };
        public IEnumerable<SelectListItem> Woods
            => woods?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Cores
            => cores?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
         public string WoodName(string? woodId = null)
            => Woods?.FirstOrDefault(x => x.Value == (woodId ?? string.Empty))?.Text ?? "Unspecified";
        public string CoreName(string? coreId = null)
            => Cores?.FirstOrDefault(x => x.Value == (coreId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, WandView v) {
            var r = base.GetValue(name, v);
            return name == nameof(WandView.Core) ? CoreName(r as string)
                : name == nameof(WandView.Wood) ? WoodName(r as string)
                : r;
        }
    }
}
