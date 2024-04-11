using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE_Lab04_RP_253_Abzalov.Data;
using SE_Lab04_RP_253_Abzalov.Models;

namespace SE_Lab04_RP_253_Abzalov.Pages.Albums
{
    public class CreateModel : PageModel
    {
        private readonly SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext _context;

        public CreateModel(SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Album Album { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Album == null || Album == null)
            {
                return Page();
            }

            _context.Album.Add(Album);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
