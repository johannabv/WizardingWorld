using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public class CharacterViewFactory {
        public Character Create(CharacterView v) => new(new CharacterData {
            ID = v.ID,
            DoB = v.DoB,
            Gender = v.Gender,
            FirstName = v.FirstName,
            LastName = v.LastName,
            HogwartsHouse = v.HogwartsHouse,
            Organisation = v.Organisation,
        });
        public CharacterView Create(Character o) => new() {
            ID = o.ID,
            DoB = o.DoB,
            Gender = o.Gender,
            FirstName = o.FirstName,
            LastName = o.LastName,
            HogwartsHouse = o.HogwartsHouse,
            Organisation = o.Organisation,
            FullName = o.ToString()
        };
    }
    public class SpellViewFactory {
        public Spell Create(SpellView v) => new(new SpellData {
            ID = v.ID,
            SpellName = v.SpellName,
            Description = v.Description,
            Type = v.Type,
        });
        public SpellView Create(Spell o) => new()
        {
            ID = o.ID,
            SpellName = o.SpellName,
            Description = o.Description,
            Type = o.Type,
            FullInfo = o.ToString()
        };
    }
}
