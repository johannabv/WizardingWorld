using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IWandsRepo : IRepo<Wand> { }
    public sealed class Wand : BaseEntity<WandData> {
        public Wand() : this(new()) { }
        public Wand(WandData d) : base(d) { }
        public string CoreId => GetValue(Data?.CoreId);
        public string WoodId => GetValue(Data?.WoodId);
        public string Info => GetValue(Data?.Info);
        public Wood? WoodItem => GetRepo.Instance<IWoodsRepo>()?.Get(WoodId);
        public CoreMaterial? CoreItem => GetRepo.Instance<ICoreMaterialsRepo>()?.Get(CoreId);
        public override string ToString() => $"{Info},{CoreItem}, {WoodItem}";
        
        public Lazy<List<Wood>> Woods {
            get {
                List<Wood> l = GetRepo.Instance<IWoodsRepo>()?
                      .GetAll(x => x.Name)?
                      .Where(x => x.Name == WoodId)?
                      .ToList() ?? new List<Wood>();
                return new Lazy<List<Wood>>(l);
            }
        }
    }
}
