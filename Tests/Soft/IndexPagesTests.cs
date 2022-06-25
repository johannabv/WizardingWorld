using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Soft {
    [TestClass] public class IndexPagesTests : PagesTests {
        [TestMethod] public async Task GetAddressesIndexPageTest()
            => await GetPageTestAsync<IAddressRepo, Address, AddressData>(x => new Address(x));
        [TestMethod] public async Task GetCharacterAddressesIndexPageTest()
            => await GetPageTestAsync<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(x => new CharacterAddress(x));
        [TestMethod] public async Task GetCharactersIndexPageTest()
            => await GetPageTestAsync<ICharactersRepo, Character, CharacterData>(x => new Character(x));
        [TestMethod] public async Task GetCoreMaterialsIndexPageTest()
            => await GetPageTestAsync<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(x => new CoreMaterial(x));
        [TestMethod] public async Task GetCountriesIndexPageTest()
            => await GetPageTestAsync<ICountriesRepo, Country, CountryData>(x => new Country(x));
        [TestMethod] public async Task GetHousesIndexPageTest()
            => await GetPageTestAsync<IHousesRepo, House, HouseData>(x => new House(x));
        [TestMethod] public async Task GetSpellsIndexPageTest()
            => await GetPageTestAsync<ISpellsRepo, Spell, SpellData>(x => new Spell(x));
        [TestMethod] public async Task GetWandsIndexPageTest()
            => await GetPageTestAsync<IWandsRepo, Wand, WandData>(x => new Wand(x));
        [TestMethod] public async Task GetWoodsIndexPageTest()
            => await GetPageTestAsync<IWoodsRepo, Wood, WoodData>(x => new Wood(x));

    }
}
