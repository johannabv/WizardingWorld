using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade.Party
{
    public class BaseView {
        [Required] public string? ID { get; set; }
    }
}
