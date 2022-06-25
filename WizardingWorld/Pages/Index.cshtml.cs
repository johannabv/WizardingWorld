using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WizardingWorld.Pages
{
    public class IndexModel : PageModel
    {
        protected readonly ILogger<IndexModel> Logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            Logger = logger;
        }

        public void OnGet()
        {

        }
    }
}