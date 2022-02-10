using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party
{
    public class Character
    {
        private const string defaultStr = "Undefined";
        private const bool defaultGender = true;
        private DateTime defaultDate => DateTime.MinValue;
        
        private CharacterData data;
        public Character() : this(new CharacterData()) { }
        public Character(CharacterData d) => data = d;
        
        public string ID => data?.ID ?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName => data?.LastName ?? defaultStr;
        public string Organisation => data?.Organisation ?? defaultStr;
        public string HogwartsHouse => data?.HogwartsHouse ?? defaultStr;
        public bool Gender => data?.Gender ?? defaultGender;
        public DateTime DoB => data?.DoB ?? defaultDate;
        public override string ToString() => $"{FirstName} {LastName}, {Organisation} ({Gender}, {DoB}, {HogwartsHouse})";
        
        public CharacterData Data => data;
    }
}
