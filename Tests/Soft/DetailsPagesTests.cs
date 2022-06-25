using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Soft {
    [TestClass] public class DetailsPagesTests : PagesTests {
        [TestMethod] public async Task GetAddressesDetailsPageTest()
            => await GetPageTestAsync<IAddressRepo, Address, AddressData>(x => new Address(x));
        [TestMethod] public async Task GetCharacterAddressesDetailsPageTest()
            => await GetPageTestAsync<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(x => new CharacterAddress(x));
        [TestMethod] public async Task GetCharactersDetailsPageTest()
            => await GetPageTestAsync<ICharactersRepo, Character, CharacterData>(x => new Character(x));
        [TestMethod] public async Task GetCoreMaterialsDetailsPageTest()
            => await GetPageTestAsync<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(x => new CoreMaterial(x));
        [TestMethod] public async Task GetCountriesDetailsPageTest()
            => await GetPageTestAsync<ICountriesRepo, Country, CountryData>(x => new Country(x));
        [TestMethod] public async Task GetHousesDetailsPageTest()
            => await GetPageTestAsync<IHousesRepo, House, HouseData>(x => new House(x));
        [TestMethod] public async Task GetSpellsDetailsPageTest()
            => await GetPageTestAsync<ISpellsRepo, Spell, SpellData>(x => new Spell(x));
        [TestMethod] public async Task GetWandsDetailsPageTest()
            => await GetPageTestAsync<IWandsRepo, Wand, WandData>(x => new Wand(x));
        [TestMethod] public async Task GetWoodsDetailsPageTest()
            => await GetPageTestAsync<IWoodsRepo, Wood, WoodData>(x => new Wood(x));

    }
}
