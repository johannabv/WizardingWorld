using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass]
    public class BaseViewTests : AbstractClassTests {
        private class testClass : BaseView { }
        protected override object createObject() => new testClass(); 
    }
}
