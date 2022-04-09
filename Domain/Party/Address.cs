using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IAddressRepo : IRepo<Address> { }
    public sealed class Address : BaseEntity<AddressData> {
        public Address() : this(new()) { }
        public Address(AddressData d) : base(d) { }
        public string Street => GetValue(Data?.Street);
        public string City => GetValue(Data?.City);
        public string Region => GetValue(Data?.Region);
        public string ZipCode => GetValue(Data?.ZipCode);
        public string Description => GetValue(Data?.Description);
        public string CountryID => GetValue(Data?.CountryID);
        public override string ToString() => $"{Street}, {City}, {CountryID} ({Description})";
        public List<CharacterAddress> CharacterAddresses
            => GetRepo.Instance<ICharacterAddressesRepo>()?
            .GetAll(x => x.AddressID)?
            .Where(x => x.AddressID == ID)?
            .ToList() ?? new List<CharacterAddress>();

        public List<Character?> Characters
            => CharacterAddresses
            .Select(x => x.Character)
            .ToList() ?? new List<Character?>();
    }
}
