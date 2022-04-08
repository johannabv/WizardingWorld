using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain {
    public abstract class BaseEntity {
        public static string DefaultStr => "Undefined";
        private static DateTime DefaultDate => DateTime.MinValue;
        protected static string GetValue(string? v) => v ?? DefaultStr;
        protected static IsoGender GetValue(IsoGender? v) => v ?? IsoGender.NotKnown;
        protected static DateTime GetValue(DateTime? v) => v ?? DefaultDate;
    } 
    public abstract class BaseEntity<TData> : BaseEntity where TData : BaseData, new() {
        public readonly TData data;
        public TData Data => data;
        public BaseEntity() : this(new TData()) { }
        public BaseEntity(TData d) => data = d; 
        public string ID => GetValue(Data?.ID);
    }
}
