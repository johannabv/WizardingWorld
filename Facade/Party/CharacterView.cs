using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardingWorld.Facade.Party {
    public class CharacterView {
        [Required] public string? ID { get; set; }
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name"), Required] public string? LastName { get; set; }
        [DisplayName("Gender"), Required] public bool? Gender { get; set; }
        [DisplayName("Date of Birth")] public DateTime? DoB { get; set; }
        [DisplayName("Hogwartz House"), Required] public string? HogwartsHouse { get; set; }
        [DisplayName("Organisation"), Required] public string? Organisation { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
}
