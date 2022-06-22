using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade {
    public abstract class NamedView : BaseView {
        [Required][DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Code")] public string? Code { get; set; }
        [Required][DisplayName("GetDescription")] public string? Description { get; set; } 
    }
}
