using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using SE_Lab04_RP_253_Abzalov.Data;
using SE_Lab04_RP_253_Abzalov.Models;

namespace SE_Lab04_RP_253_Abzalov.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext _context;

        public IndexModel(SE_Lab04_RP_253_Abzalov.Data.SE_Lab04_RP_253_AbzalovContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AlbumGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from a in _context.Album
                                            orderby a.Genre
                                            select a.Genre;
            var albums = from a in _context.Album select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                albums = albums.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(AlbumGenre))
            {
                albums = albums.Where(x => x.Genre == AlbumGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Album = await albums.ToListAsync();
        }
    }
}
