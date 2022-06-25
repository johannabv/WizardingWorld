using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class CharacterAddressesRepo : Repo<CharacterAddress, CharacterAddressData>, ICharacterAddressesRepo {
        public CharacterAddressesRepo(WizardingWorldDb? db) : base(db, db?.CharacterAddresses) { }
        protected internal override CharacterAddress ToDomain(CharacterAddressData d) => new(d);
        internal override IQueryable<CharacterAddressData> AddFilter(IQueryable<CharacterAddressData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.CharacterId.Contains(y)
                  || x.AddressId.Contains(y)
                  || x.Id.Contains(y)
                  || x.UseFor.ToString().Contains(y)
            );
        }
    }
}
