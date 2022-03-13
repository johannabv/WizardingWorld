using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade.Party {
    public abstract class BaseView {
        [Required] public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}
