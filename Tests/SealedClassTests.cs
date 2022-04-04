﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public abstract class SealedClassTests<TClass> : BaseTests where TClass : class, new()
    {
        protected override object CreateObj() => new TClass();
        [TestMethod] public void IsSealedTest() => IsTrue(obj?.GetType()?.IsSealed ?? false);
    }
}
