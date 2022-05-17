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
        public override string ToString() => $"{Street}, {City}, {Country?.Name} ({Description})";
        public Country? Country => GetRepo.Instance<ICountriesRepo>().Get(CountryID);

        public Lazy<List<CharacterAddress>> CharacterAddresses { 
            get {
                List<CharacterAddress> l = GetRepo.Instance<ICharacterAddressesRepo>()?
                      .GetAll(x => x.AddressID)?
                      .Where(x => x.AddressID == ID)?
                      .ToList() ?? new List<CharacterAddress>();
                return new Lazy<List<CharacterAddress>>(l);
            } 
        }
            
        public Lazy<List<Character?>> Characters {
            get {
                List<Character?> l = CharacterAddresses
                    .Value
                    .Select(x => x.Character)
                    .ToList() ?? new List<Character?>();
                return new Lazy<List<Character?>>(l);
            }
        }
           
    }
}
