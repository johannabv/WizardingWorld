using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass]  public class WoodViewFactoryTests
        : ViewFactoryTests<WoodViewFactory, WoodView, Wood, WoodData> {
        protected override Wood ToObject(WoodData d) => new(d);
    }
}
