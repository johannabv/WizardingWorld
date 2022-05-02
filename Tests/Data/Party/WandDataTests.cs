using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class WandDataTests : SealedClassTests<WandData, BaseData> {
        [TestMethod] public void CoreIDTest() => IsProperty<string?>();
        [TestMethod] public void WoodIDTest() => IsProperty<string?>();
        [TestMethod] public void InfoTest() => IsProperty<string?>(); 
    }
}
