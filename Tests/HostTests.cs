using System.Net.Http;

namespace Tests {
    public class HostTests : AssertTests {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        static HostTests() {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
    }
}
