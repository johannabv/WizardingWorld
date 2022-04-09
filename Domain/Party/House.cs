using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IHousesRepo : IRepo<House> { }
    public sealed class House : BaseEntity<HouseData> {
        public House() : this(new ()) { }
        public House(HouseData d) : base(d) { }
        public string HouseName => GetValue(Data?.HouseName);
        public string FounderName => GetValue(Data?.FounderName);
        public string HeadOfHouseName => GetValue(Data?.HeadOfHouseName);
        public string Color => GetValue(Data?.Color);
        public string Description => GetValue(Data?.Description);
        public override string ToString() => $"{HouseName} ({Color}), {Description}";
    }
}
