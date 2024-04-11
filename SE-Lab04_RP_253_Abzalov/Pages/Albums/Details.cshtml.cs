using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE_Lab04_RP_253_Abzalov.Data;
using SE_Lab04_RP_253_Abzalov.Models;

namespace SE_Lab04_RP_253_Abzalov.Pages.Albums
{
    public class DetailsModel : PageModel
    {
        private readonly SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext _context;

        public DetailsModel(SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext context)
        {
            _context = context;
        }

      public Album Album { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            else 
            {
                Album = album;
            }
            return Page();
        }
    }
}
