using WizardingWorld.Data;

namespace WizardingWorld.Domain {
    public abstract class Entity { }

    public abstract class Entity<TData> : Entity where TData : EntityData, new() {
        public readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
    }
}
