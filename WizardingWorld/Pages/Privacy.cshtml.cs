﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WizardingWorld.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
        }
    }
}