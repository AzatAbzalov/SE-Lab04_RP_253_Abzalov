using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE_Lab04_RP_253_Abzalov.Data;
using SE_Lab04_RP_253_Abzalov.Models;

namespace SE_Lab04_RP_253_Abzalov.Pages.Albums
{
    public class EditModel : PageModel
    {
        private readonly SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext _context;

        public EditModel(SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album =  await _context.Album.FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            Album = album;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(Album.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlbumExists(int id)
        {
          return (_context.Album?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
