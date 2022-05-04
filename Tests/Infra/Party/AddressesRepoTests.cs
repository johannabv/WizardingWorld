using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Infra.Party {
    [TestClass] public class AddressesRepoTests : SealedRepoTests<AddressesRepo, Repo<Address, AddressData>, Address, AddressData> {
        protected override AddressesRepo CreateObj() => new(GetRepo.Instance<WizardingWorldDb>());
        protected override object? GetSet(WizardingWorldDb db) => db.Addresses;
    }
}
