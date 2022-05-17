using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public sealed class AddressesRepo : Repo<Address, AddressData>, IAddressRepo {
        public AddressesRepo(WizardingWorldDb? db) : base(db, db?.Addresses) { }
        protected internal override Address ToDomain(AddressData d) => new(d);
        internal override IQueryable<AddressData> AddFilter(IQueryable<AddressData> q) {
            string? y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Street.Contains(y)
                  || x.CountryID.Contains(y)
                  || x.ID.Contains(y)
                  || x.City.Contains(y)
                  || x.Region.Contains(y)
                  || x.ZipCode.Contains(y)
                  || x.Description.Contains(y)
            );
        }
    }
}
