﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Infra.Party {
    [TestClass] public class CoreMaterialsRepoTests : SealedRepoTests<CoreMaterialsRepo, Repo<CoreMaterial, CoreMaterialData>, CoreMaterial, CoreMaterialData> {
        protected override CoreMaterialsRepo CreateObj() => new(GetRepo.Instance<WizardingWorldDb>());
        protected override object? GetSet(WizardingWorldDb db) => db.Cores;
    }
}
