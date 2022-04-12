using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade {
    public abstract class NamedView : BaseView {
        [DisplayName("Name"), Required] public string? Name { get; set; }
        [DisplayName("Code")] public string? Code { get; set; }
        [DisplayName("Description"), Required] public string? Description { get; set; } 
    }
}
