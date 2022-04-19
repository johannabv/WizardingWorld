using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;

namespace Tests.Facade.Party {
    [TestClass]
    public class BaseViewTests : AbstractClassTests<BaseView, object> {
        private class TestClass : BaseView { }
        protected override BaseView CreateObj() => new TestClass(); 
    }
}
