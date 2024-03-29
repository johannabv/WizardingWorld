﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WizardingWorld.Domain;

namespace WizardingWorld.Tests.Soft {
    public abstract class PagesTests : HostTests {
        public static async Task GetPageTestAsync<TRepo, TObj, TData>(Func<TData, TObj> toObj)
            where TRepo : class, IRepo<TObj>
            where TObj : BaseEntity, new() {

            string name = GetName(new TObj());
            string handler = GetHandler(name);

            _ = AddRandomItems<TRepo, TObj, TData>(out int cnt, toObj);

            HttpResponseMessage page = await Client.GetAsync($"/{name}?handler={handler}");
            AreEqual(HttpStatusCode.OK, page.StatusCode);

            string html = await page.Content.ReadAsStringAsync();
            IsTrue(html.Contains($"<h1>Index</h1>"));
            IsTrue(html.Contains($"<h4>{name}</h4>"));
        }
        public static string GetName<TObj>(TObj? obj) {
            string typeName = obj.GetType().Name;
            if (typeName.EndsWith('y')) return typeName[..^1] + "ies";
            if (typeName.EndsWith('s')) return typeName + "es";
            return typeName + "s";
        }
        public static string GetHandler(string name)
            => GetCallingMember(nameof(GetPageTestAsync))
                .Replace("PageTest", string.Empty)
                .Replace("Get", string.Empty)
                .Replace(name, string.Empty);

    }
}