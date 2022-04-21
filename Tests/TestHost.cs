using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests {
    public class TestHost<TProgram> : WebApplicationFactory<TProgram> where TProgram : class { }
}
