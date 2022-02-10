using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Characters
{
    //TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    //TODO To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class CharactersPage : PageModel
    {
        [BindProperty] public CharacterView Character { get; set; }
        private readonly ApplicationDbContext context;
        public IList<CharacterView> Characters { get; set; }
        
        public CharactersPage(ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate()
        {
            return Page();
        }
        
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new CharacterViewFactory().Create(Character).Data;

            context.Characters.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        private async Task<CharacterView> getPerson(string id)
        {
            if (id == null) return null;
            var d = await context.Characters.FirstOrDefaultAsync(m => m.ID == id);
            if (d == null) return null;
            return new CharacterViewFactory().Create(new Character(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Characters.FindAsync(id);

            if (d != null)
            {
                context.Characters.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Character = await getPerson(id);
            return Character == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new CharacterViewFactory().Create(Character).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!characterExists(Character.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "Index");
        }
        private bool characterExists(string id)
            => context.Characters.Any(e => e.ID == id);

        public async Task OnGetIndexAsync()
        {
            var list = await context.Characters.ToListAsync();
            Characters = new List<CharacterView>();
            foreach (var d in list)
            {
                var v = new CharacterViewFactory().Create(new Character(d));
                Characters.Add(v);
            }
            
        }
    }
}
