using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IWandsRepo : IRepo<Wand> { }
    public sealed class Wand : BaseEntity<WandData> {
        public Wand() : this(new()) { }
        public Wand(WandData d) : base(d) { }
        public string Core => GetValue(Data?.Core);
        public string Wood => GetValue(Data?.Wood);
        public string Info => GetValue(Data?.Info);
        public string CoreInfo => GetValue(Data?.CoreInfo);
        public string WoodInfo => GetValue(Data?.WoodInfo);
        public override string ToString() => $"{Info},{Core}, {Wood}";

    }
}
