using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public abstract class AbstractClassTests : BaseTests{
        [TestMethod] public void IsAbstractTest() => IsTrue(obj?.GetType()?.BaseType?.IsAbstract ?? false);
    }
}
