using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class WandDataTests : SealedClassTests<WandData, BaseData> {
        [TestMethod] public void CoreIdTest() => IsProperty<string?>();
        [TestMethod] public void WoodIdTest() => IsProperty<string?>();
        [TestMethod] public void InfoTest() => IsProperty<string?>(); 
    }
}
