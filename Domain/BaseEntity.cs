using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain {
    public abstract class BaseEntity {
        public static string DefaultStr => "Undefined";
        private static DateTime DefaultDate => DateTime.MinValue;
        protected static string GetValue(string? v) => v ?? DefaultStr;
        protected static IsoGender GetValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static DateTime GetValue(DateTime? v) => v ?? DefaultDate;
    } 
    public abstract class BaseEntity<TData> : BaseEntity where TData : BaseData, new() {
        public TData Data { get; }
        public BaseEntity() : this(new TData()) { }
        public BaseEntity(TData d) => Data = d; 
        public string ID => GetValue(Data?.ID);
    }
}
