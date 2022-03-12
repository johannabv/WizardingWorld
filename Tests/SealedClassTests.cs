﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    public abstract class SealedClassTests<TClass> : BaseTests where TClass : class, new() {
        protected override object createObject() => new TClass();
        [TestMethod] public void isSealedTest() => isTrue(obj?.GetType()?.IsSealed ?? false);
    }
}
