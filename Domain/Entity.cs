using WizardingWorld.Data;

namespace WizardingWorld.Domain {
    public abstract class Entity {
        private const string defaultStr = "Undefined";
        private const bool defaultBool = false;
        private static DateTime DefaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? defaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? DefaultDate;
    } 
    public abstract class Entity<TData> : Entity where TData : EntityData, new() {
        public readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d; 
        public string ID => getValue(Data?.ID);
    }
}
