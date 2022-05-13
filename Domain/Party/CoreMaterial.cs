using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICoreMaterialsRepo : IRepo<CoreMaterial> { }
    public sealed class CoreMaterial : NamedEntity<CoreMaterialData> {
        public CoreMaterial() : this(new()) { }
        public CoreMaterial(CoreMaterialData d) : base(d) { }
        public override string ToString() => $"{Name}: {Description}";
    }
}
