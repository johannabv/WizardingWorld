using WizardingWorld.Data;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Domain {
    public abstract class BaseEntity {
        public static string DefaultStr => "Undefined";
        private static DateTime DefaultDate => DateTime.MinValue;
        protected static string GetValue(string? v) => v ?? DefaultStr;
        protected static IsoGender GetValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static AddressUse GetValue(AddressUse? v) => v ?? AddressUse.NotKnown;
        protected static Side GetValue(Side? v) => v ?? Side.NotKnown;
        protected static DateTime GetValue(DateTime? v) => v ?? DefaultDate;
    } 
    public abstract class BaseEntity<TData> : BaseEntity where TData : BaseData, new() {
        public TData Data { get; }
        public BaseEntity() : this(new TData()) { }
        public BaseEntity(TData d) => Data = d; 
        public string ID => GetValue(Data?.ID);
    }
}
