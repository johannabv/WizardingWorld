using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Domain;
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
            => woods?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Cores
            => cores?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> WoodInfos
            => woods?.GetAll(x => x.Description)?
            .Select(x => new SelectListItem(x.Description, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> CoreInfos
            => cores?.GetAll(x => x.Description)?
            .Select(x => new SelectListItem(x.Description, x.ID)) 
            ?? new List<SelectListItem>();
        
        public string WoodDescription(string? woodId = null)
            => Woods?.FirstOrDefault(x => x.Value == (woodId ?? string.Empty))?.Text ?? "Unspecified";
        public string CoreDescription(string? coreId = null)
            => Cores?.FirstOrDefault(x => x.Value == (coreId ?? string.Empty))?.Text ?? "Unspecified";
        public string CorrectCoreInfo(string? coreId = null) { 
            var CoreInfos = cores?.GetAll(x => x.Description)?.Select(x => new SelectListItem(x.Description, x.ID)) ?? new List<SelectListItem>();
            return CoreInfos?.FirstOrDefault(x => x.Value == (coreId.Split(":")[0] ?? string.Empty))?.Text ?? "Unspecified";
        }
        public string CorrectWoodInfo(string? woodId = null) {
            var woodInfo = woods?.GetAll(x => x.Description)?.Select(x => new SelectListItem(x.Description, x.ID)) ?? new List<SelectListItem>();
            return woodInfo?.FirstOrDefault(x => x.Value == (woodId.Split(":")[0] ?? string.Empty))?.Text ?? "Unspecified";
        }
        public string WoodName(string? woodId = null) {
            var WoodNames = woods?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.ID)) ?? new List<SelectListItem>();
            return WoodNames?.FirstOrDefault(x => x.Value == (woodId.Split(":")[0] ?? string.Empty))?.Text ?? "Unspecified";
        }
        public string CoreName(string? coreId = null) { 
            var CoreNames = cores?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.ID)) ?? new List<SelectListItem>();
            var d = CoreNames?.FirstOrDefault(x => x.Value == (coreId.Split(":")[0] ?? string.Empty))?.Text ?? "Unspecified";
            return d;
        }
        public override object? GetValue(string name, WandView v) {
            var r = base.GetValue(name, v);
            return name == nameof(WandView.Core) ? CoreDescription(r as string)
                : name == nameof(WandView.Wood) ? WoodDescription(r as string)
                : r;
        }
    }
}
