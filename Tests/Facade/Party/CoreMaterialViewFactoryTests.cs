using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CoreMaterialViewFactoryTests
        : ViewFactoryTests<CoreMaterialViewFactory, CoreMaterialView, CoreMaterial, CoreMaterialData> {
        protected override CoreMaterial ToObject(CoreMaterialData d) => new(d);
    }
}
