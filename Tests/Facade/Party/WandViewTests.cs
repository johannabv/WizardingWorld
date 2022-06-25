using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class WandViewTests : SealedClassTests<WandView, BaseView> {
        [TestMethod] public void CoreIdTest() => IsRequired<string?>("Core");
        [TestMethod] public void WoodIdTest() => IsRequired<string?>("Wood");
        [TestMethod] public void InfoTest() => IsDisplayNamed<string?>("Info");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full Wand Info");
    }
    [TestClass] public class WandViewFactoryTests
        : ViewFactoryTests<WandViewFactory, WandView, Wand, WandData> {
        protected override Wand ToObject(WandData d) => new(d);
    }
}
