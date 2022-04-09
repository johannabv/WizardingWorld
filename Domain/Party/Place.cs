using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IPlaceRepo : IRepo<Place> { }
    public sealed class Place : BaseEntity<PlaceData> {
        public Place() : this(new()) { }
        public Place(PlaceData d) : base(d) { }
        public string Street => GetValue(Data?.Street);
        public string City => GetValue(Data?.City);
        public string Region => GetValue(Data?.Region);
        public string ZipCode => GetValue(Data?.ZipCode);
        public string Description => GetValue(Data?.Description);
        public string CountryID => GetValue(Data?.CountryID);
        public override string ToString() => $"{Street}, {City}, {CountryID} ({Description})";

        public Country? Country { get; set; }
    }
}
