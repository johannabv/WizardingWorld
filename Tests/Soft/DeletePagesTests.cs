using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Soft {
    [TestClass] public class DeletePagesTests : PagesTests {
        [TestMethod] public async Task GetAddressesDeletePageTest()
            => await GetPageTestAsync<IAddressRepo, Address, AddressData>(x => new Address(x));
        [TestMethod] public async Task GetCharacterAddressesDeletePageTest()
            => await GetPageTestAsync<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(x => new CharacterAddress(x));
        [TestMethod] public async Task GetCharactersDeletePageTest()
            => await GetPageTestAsync<ICharactersRepo, Character, CharacterData>(x => new Character(x));
        [TestMethod] public async Task GetCoreMaterialsDeletePageTest()
            => await GetPageTestAsync<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(x => new CoreMaterial(x));
        [TestMethod] public async Task GetCountriesDeletePageTest()
            => await GetPageTestAsync<ICountriesRepo, Country, CountryData>(x => new Country(x));
        [TestMethod] public async Task GetHousesDeletePageTest()
            => await GetPageTestAsync<IHousesRepo, House, HouseData>(x => new House(x));
        [TestMethod] public async Task GetSpellsDeletePageTest()
            => await GetPageTestAsync<ISpellsRepo, Spell, SpellData>(x => new Spell(x));
        [TestMethod] public async Task GetWandsDeletePageTest()
            => await GetPageTestAsync<IWandsRepo, Wand, WandData>(x => new Wand(x));
        [TestMethod] public async Task GetWoodsDeletePageTest()
            => await GetPageTestAsync<IWoodsRepo, Wood, WoodData>(x => new Wood(x)); 
    }
}
