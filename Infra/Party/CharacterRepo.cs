﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CharacterRepo : Repo<Character, CharacterData>, ICharacterRepo {
        public CharacterRepo(DbContext c, DbSet<CharacterData> s) : base(c, s) { }
        protected override Character toDomain(CharacterData d) => new Character(d);
    }
}
