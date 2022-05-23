using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass]  public class WoodViewFactoryTests
        : ViewFactoryTests<WoodViewFactory, WoodView, Wood, WoodData> {
        protected override Wood ToObject(WoodData d) => new(d);
    }
}
