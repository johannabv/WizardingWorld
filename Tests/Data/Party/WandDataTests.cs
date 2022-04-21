using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class WandDataTests : SealedClassTests<WandData, BaseData> {
        [TestMethod] public void CoreTest() => IsProperty<string?>();
        [TestMethod] public void CoreInfoTest() => IsProperty<string?>();
        [TestMethod] public void WoodTest() => IsProperty<string?>();
        [TestMethod] public void WoodInfoTest() => IsProperty<string?>();
        [TestMethod] public void InfoTest() => IsProperty<string?>(); 
    }
}
