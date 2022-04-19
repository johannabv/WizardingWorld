using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public abstract class SealedClassTests<TClass, TBaseClass>
        : BaseTests<TClass, TBaseClass> where TClass : class, new() where TBaseClass : class {
        protected override TClass CreateObj() => new TClass();
        [TestMethod] public void IsSealedTest() => IsTrue(obj?.GetType()?.IsSealed ?? false);
    }
}
