using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CoreMaterialViewFactoryTests
        : ViewFactoryTests<CoreViewFactory, CoreMaterialView, CoreMaterial, CoreMaterialData> {
        protected override CoreMaterial ToObject(CoreMaterialData d) => new(d);
    }
}
