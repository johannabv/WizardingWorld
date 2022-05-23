using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class WandsPage : PagedPage<WandView, Wand, IWandsRepo> {
        private readonly IWoodsRepo woods;
        private readonly ICoreMaterialsRepo cores;
        public WandsPage(IWandsRepo r, ICoreMaterialsRepo c, IWoodsRepo w) : base(r) {
            woods = w;
            cores = c;
        }
        protected override Wand ToObject(WandView? item) => new WandViewFactory().Create(item);
        protected override WandView ToView(Wand? entity) => new WandViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(WandView.Info),
            nameof(WandView.CoreID),
            nameof(WandView.WoodID)
        };
        public IEnumerable<SelectListItem> WoodInfos
            => woods?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> CoreInfos
            => cores?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID)) 
            ?? new List<SelectListItem>();
        public string WoodDescription(string? woodId = null)
            => WoodInfos?.FirstOrDefault(x => x.Value == (woodId ?? string.Empty))?.Text ?? "Unspecified";
        public string CoreDescription(string? coreId = null)
            => CoreInfos?.FirstOrDefault(x => x.Value == (coreId ?? string.Empty))?.Text ?? "Unspecified";
        
        public override object? GetValue<T>(string name, T v) {
            object? r = base.GetValue(name, v);
            return name == nameof(WandView.CoreID) ? CoreDescription(r as string)
                : name == nameof(WandView.WoodID) ? WoodDescription(r as string)
                : r;
        }
        public Lazy<List<Wood>> Woods => ToObject(Item).Woods;
    }
}
