using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party
{
    public class Character : Entity<CharacterData>
    {
        private const string defaultStr = "Undefined";
        private const bool defaultGender = true;
        private DateTime defaultDate => DateTime.MinValue;

        public Character() : this(new CharacterData()) { }
        public Character(CharacterData d) : base(d) { }

        public string ID => Data?.ID ?? defaultStr;
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public string Organisation => Data?.Organisation ?? defaultStr;
        public string HogwartsHouse => Data?.HogwartsHouse ?? defaultStr;
        public bool Gender => Data?.Gender ?? defaultGender;
        public DateTime DoB => Data?.DoB ?? defaultDate;

        public override string ToString() => $"{FirstName} {LastName}, {Organisation} ({Gender}, {DoB}, {HogwartsHouse})";

        public CharacterData Data => data;
    }
}
