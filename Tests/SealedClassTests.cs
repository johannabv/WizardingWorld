using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Tests;

namespace Tests {
    public abstract class SealedClassTests<TClass, TBaseClass>
        : SealedBaseTests<TClass, TBaseClass> where TClass : class, new() where TBaseClass : class {
        protected override TClass CreateObj() => new();
    }
    public abstract class SealedBaseTests<TClass, TBaseClass>
        : BaseTests<TClass, TBaseClass> where TClass : class where TBaseClass : class {
        [TestMethod] public void IsSealedTest() => isSealedTest();
        protected virtual void isSealedTest() => IsTrue(obj?.GetType()?.IsSealed ?? false);
    }
}
