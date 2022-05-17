using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Tests;

namespace Tests {
    public abstract class AbstractClassTests<TClass, TBaseClass> 
        : BaseTests<TClass, TBaseClass> 
        where TClass : class where TBaseClass : class {
        [TestMethod] public void IsAbstractTest() => IsTrue(obj?.GetType()?.BaseType?.IsAbstract ?? false);
    }
}