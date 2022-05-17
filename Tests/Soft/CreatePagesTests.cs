using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Soft {
    [TestClass] public class CreatePagesTests : PagesTests {
        [TestMethod] public async Task GetAddressesCreatePageTest()
            => await GetPageTestAsync<IAddressRepo, Address, AddressData>(x => new Address(x));
        [TestMethod] public async Task GetCharacterAddressesCreatePageTest()
            => await GetPageTestAsync<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(x => new CharacterAddress(x));
        [TestMethod] public async Task GetCharactersCreatePageTest()
            => await GetPageTestAsync<ICharactersRepo, Character, CharacterData>(x => new Character(x));
        [TestMethod] public async Task GetCoreMaterialsCreatePageTest()
            => await GetPageTestAsync<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(x => new CoreMaterial(x));
        [TestMethod] public async Task GetCountryCurrenciesCreatePageTest()
            => await GetPageTestAsync<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(x => new CountryCurrency(x));
        [TestMethod] public async Task GetCountriesCreatePageTest()
            => await GetPageTestAsync<ICountriesRepo, Country, CountryData>(x => new Country(x));
        [TestMethod] public async Task GetCurrenciesCreatePageTest()
            => await GetPageTestAsync<ICurrenciesRepo, Currency, CurrencyData>(x => new Currency(x));
        [TestMethod] public async Task GetHousesCreatePageTest()
            => await GetPageTestAsync<IHousesRepo, House, HouseData>(x => new House(x));
        [TestMethod] public async Task GetSpellsCreatePageTest()
            => await GetPageTestAsync<ISpellsRepo, Spell, SpellData>(x => new Spell(x));
        [TestMethod] public async Task GetWandsCreatePageTest()
            => await GetPageTestAsync<IWandsRepo, Wand, WandData>(x => new Wand(x));
        [TestMethod] public async Task GetWoodsCreatePageTest()
            => await GetPageTestAsync<IWoodsRepo, Wood, WoodData>(x => new Wood(x));

    }
}