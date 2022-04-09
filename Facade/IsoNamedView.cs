using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade {
    public abstract class IsoNamedView : NamedView {
        [Required] [DisplayName("ISO three-letter code")] public new string? Code { get; set; }
        [DisplayName("English name")] public new string? Name { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }

}
