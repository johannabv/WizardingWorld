﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Domain {
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity<CountryData>, BaseEntity> {
        private CountryData? d;
        private class TestClass : BaseEntity<CountryData> {
            public TestClass() : this(new CountryData()) { }
            public TestClass(CountryData d) : base(d) { }
        }
        protected override BaseEntity<CountryData> CreateObj() {
            d = GetRandom.Value<CountryData>();
            return new TestClass(d);
        }
        [TestMethod] public void IDTest() => IsReadOnly(obj.Data.ID);
        [TestMethod] public void DataTest() => IsReadOnly(d);
        [TestMethod] public void DefaultStrTest() => AreEqual("Undefined", BaseEntity.DefaultStr);
        [TestMethod] public void DefaultDateTest() => AreEqual(DateTime.MinValue, BaseEntity.DefaultDate);
    }
}
