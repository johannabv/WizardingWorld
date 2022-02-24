using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WizardingWorld.Data;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Pages.Characters
{
    public class CharactersPage : PageModel
    {
        [BindProperty] public CharacterView Character { get; set; }
        private readonly ICharacterRepo repo;
        public IList<CharacterView> Characters { get; set; }

        public CharactersPage(ApplicationDbContext c) => repo = new CharacterRepo(c, c.Characters);
        public IActionResult OnGetCreate() => Page();

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new CharacterViewFactory().Create(Character));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new CharacterViewFactory().Create(Character);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<PageResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Characters = new List<CharacterView>();
            foreach (var obj in list)
            {
                var v = new CharacterViewFactory().Create(obj);
                Characters.Add(v);
            }
            return Page();
        }

        private async Task<CharacterView> getPerson(string id) => new CharacterViewFactory().Create(await repo.GetAsync(id));
    }
}
