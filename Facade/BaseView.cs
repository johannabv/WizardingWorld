using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Facade {
    public abstract class BaseView {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required] public byte[] Token { get; set; } = Array.Empty<byte>();
    }
}
