using System.ComponentModel.DataAnnotations;

namespace WizardingWorld.Data {
    public abstract class BaseData {
        public static string NewId => Guid.NewGuid().ToString();
        public string ID { get; set; } = NewId;
        protected static byte[] Empty => Array.Empty<byte>();
        [Timestamp] public byte[] Token { get; set; } = Empty;
    }
}
