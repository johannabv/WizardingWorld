using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CharacterAddressesRepo : Repo<CharacterAddress, CharacterAddressData>, ICharacterAddressesRepo {
        public CharacterAddressesRepo(WizardingWorldDb? db) : base(db, db?.CharacterAddresses) { }
        protected override CharacterAddress ToDomain(CharacterAddressData d) => new(d);
        internal override IQueryable<CharacterAddressData> AddFilter(IQueryable<CharacterAddressData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Code.Contains(y)
                  || x.CharacterID.Contains(y)
                  || x.AddressID.Contains(y)
                  || x.ID.Contains(y)
                  || x.Name.Contains(y));
        }
    }
}
