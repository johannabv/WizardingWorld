using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WandTests : SealedClassTests<WandData> {
        [TestMethod] public void CoreTest() => IsInconclusive();
        [TestMethod] public void WoodTest() => IsInconclusive();
        [TestMethod] public void InfoTest() => IsInconclusive();
        [TestMethod] public void ToStringTest() => IsInconclusive();
    }
}
