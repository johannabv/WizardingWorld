using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class WoodViewTests : SealedClassTests<WoodView, BaseView> {
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
        [TestMethod] public void NameTest() => IsRequired<string?>("Name of wood");
        [TestMethod] public void TraitsTest() => IsDisplayNamed<string?>("Traits");
        [TestMethod] public void DescriptionTest() => IsRequired<string?>("Description");
    }
    [TestClass] public class WoodViewFactoryTests
        : ViewFactoryTests<WoodViewFactory, WoodView, Wood, WoodData> {
        protected override Wood ToObject(WoodData d) => new(d);
    }
}
