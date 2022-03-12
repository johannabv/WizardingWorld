using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardingWorld.Facade.Party {
    public class SpellView : BaseView{
        [DisplayName("Name of spell"), Required] public string? SpellName { get; set; }
        [Required] public string? Description { get; set; }
        public string? Type { get; set; }
        [DisplayName("Full info")] public string? FullInfo { get; set; }
    }
}
