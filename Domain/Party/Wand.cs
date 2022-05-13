using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IWandsRepo : IRepo<Wand> { }
    public sealed class Wand : BaseEntity<WandData> {
        public Wand() : this(new()) { }
        public Wand(WandData d) : base(d) { }
        public string CoreID => GetValue(Data?.CoreID);
        public string WoodID => GetValue(Data?.WoodID);
        public string Info => GetValue(Data?.Info);
        public Wood? WoodItem => GetRepo.Instance<IWoodsRepo>().Get(WoodID);
        public CoreMaterial? CoreItem => GetRepo.Instance<ICoreMaterialsRepo>().Get(CoreID);
        public override string ToString() => $"{Info},{CoreItem}, {WoodItem}";
        public List<Wood> Woods
            => GetRepo.Instance<IWoodsRepo>()?
            .GetAll(x => x.Name)?
            .Where(x => x.Name == WoodID)?
            .ToList() ?? new List<Wood>();
    }
}
