using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tests;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Soft {
    public abstract class PagesTests : HostTests {
        public async Task GetPageTestAsync<TRepo, TObj, TData>(Func<TData, TObj> toObj)
            where TRepo : class, IRepo<TObj>
            where TObj : BaseEntity, new() {

            string name = GetName(new TObj());
            string handler = GetHandler(name);
            int cnt;

            _ = AddRandomItems<TRepo, TObj, TData>(out cnt, toObj);

            HttpResponseMessage page = await client.GetAsync($"/{name}?handler={handler}");
            AreEqual(HttpStatusCode.OK, page.StatusCode);

            string html = await page.Content.ReadAsStringAsync();
            IsTrue(html.Contains($"<h1>Index</h1>"));
            IsTrue(html.Contains($"<h4>{name}</h4>"));
        }
        public static string GetName<TObj>(TObj obj) {
            string typeName = obj.GetType().Name;
            return !typeName.EndsWith('y') ? typeName + "s" : typeName[..^1] + "ies";
        }
        public static string GetHandler(string name)
            => GetCallingMember(nameof(GetPageTestAsync))
                .Replace("PageTest", string.Empty)
                .Replace("Get", string.Empty)
                .Replace(name, string.Empty);

    }
}
