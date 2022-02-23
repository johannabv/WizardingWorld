using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardingWorld.Data.Party
{
    public class CharacterData : EntityData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DoB { get; set; }
        public string? HogwartsHouse { get; set; }
        public string? Organisation { get; set; }
    }
}
