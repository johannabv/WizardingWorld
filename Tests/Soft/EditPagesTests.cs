using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Soft {
    [TestClass] public class EditPagesTests : PagesTests {
        [TestMethod] public async Task GetAddressesEditPageTest()
            => await GetPageTestAsync<IAddressRepo, Address, AddressData>(x => new Address(x));
        [TestMethod] public async Task GetCharacterAddressesEditPageTest()
            => await GetPageTestAsync<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(x => new CharacterAddress(x));
        [TestMethod] public async Task GetCharactersEditPageTest()
            => await GetPageTestAsync<ICharactersRepo, Character, CharacterData>(x => new Character(x));
        [TestMethod] public async Task GetCoreMaterialsEditPageTest()
            => await GetPageTestAsync<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(x => new CoreMaterial(x));
        [TestMethod] public async Task GetCountryCurrenciesEditPageTest()
            => await GetPageTestAsync<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(x => new CountryCurrency(x));
        [TestMethod] public async Task GetCountriesEditPageTest()
            => await GetPageTestAsync<ICountriesRepo, Country, CountryData>(x => new Country(x));
        [TestMethod] public async Task GetCurrenciesEditPageTest()
            => await GetPageTestAsync<ICurrenciesRepo, Currency, CurrencyData>(x => new Currency(x));
        [TestMethod] public async Task GetHousesEditPageTest()
            => await GetPageTestAsync<IHousesRepo, House, HouseData>(x => new House(x));
        [TestMethod] public async Task GetSpellsEditPageTest()
            => await GetPageTestAsync<ISpellsRepo, Spell, SpellData>(x => new Spell(x));
        [TestMethod] public async Task GetWandsEditPageTest()
            => await GetPageTestAsync<IWandsRepo, Wand, WandData>(x => new Wand(x));
        [TestMethod] public async Task GetWoodsEditPageTest()
            => await GetPageTestAsync<IWoodsRepo, Wood, WoodData>(x => new Wood(x));

    }
}
