using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party; 

namespace WizardingWorld.Pages {
    public class CharactersPage : PageModel {
        [BindProperty] public CharacterView Item { get; set; }
        private readonly ICharacterRepo repo;
        public IList<CharacterView> Items { get; set; } 
        public CharactersPage(ICharacterRepo r) => repo = r;
        public IActionResult OnGetCreate() => Page(); 
        public string ItemId => Item?.ID ?? string.Empty;
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new CharacterViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id) {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id) {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id) {
            Item = await getPerson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = new CharacterViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<PageResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<CharacterView>();
            foreach (var obj in list) {
                var v = new CharacterViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();
        } 
        private async Task<CharacterView> getPerson(string id) => new CharacterViewFactory().Create(await repo.GetAsync(id));
    }
}
