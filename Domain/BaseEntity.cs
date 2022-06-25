using WizardingWorld.Data;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Domain {
    public abstract class BaseEntity {
        public static string DefaultStr => "Undefined";
        public static DateTime DefaultDate => DateTime.MinValue;
        protected static string GetValue(string? v) => v ?? DefaultStr;
        protected static IsoGender GetValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static AddressUse GetValue(AddressUse? v) => v ?? AddressUse.NotKnown;
        protected static Side GetValue(Side? v) => v ?? Side.NotKnown;
        protected static DateTime GetValue(DateTime? v) => v ?? DefaultDate;
        public abstract string Id { get; }
        public abstract byte[] Token { get; }
    } 
    public abstract class BaseEntity<TData> : BaseEntity where TData : BaseData, new() {
        public TData Data { get; }
        public BaseEntity() : this(new TData()) { }
        public BaseEntity(TData d) => Data = d; 
        public override string Id => GetValue(Data?.Id);
        public override byte[] Token => Data?.Token ?? Array.Empty<byte>();
    }
}
