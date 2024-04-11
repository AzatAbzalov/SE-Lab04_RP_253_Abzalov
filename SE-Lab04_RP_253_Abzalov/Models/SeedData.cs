using Microsoft.EntityFrameworkCore;
using SE_Lab04_RP_253_Abzalov.Data;

namespace SE_Lab04_RP_253_Abzalov.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SE_Lab04_RP_253_AbzalovContext(
                serviceProvider.GetRequiredService<DbContextOptions<SE_Lab04_RP_253_AbzalovContext>>()))
            {
                if(context == null || context.Album == null) 
                {
                    throw new ArgumentNullException("Null RazorPagesAlbumContext");
                }

                if (context.Album.Any()) 
                {
                    return;
                }
                context.Album.AddRange(
                    new Album
                    {
                        Title = "Donda",
                        ReleaseDate = DateTime.Parse("2022-8-29"),
                        Genre = "Hip-hop",
                        Price = 10.0M,
                        Author = "Kanye West",
                        TrackNumbers = 27,
                        TotalDuration = TimeSpan.Parse("1:48:00"),
                        Rating = "R"
                    },
                     new Album
                     {
                         Title = "Life of DON",
                         ReleaseDate = DateTime.Parse("2021-10-8"),
                         Genre = "Hip-hop",
                         Price = 15.0M,
                         Author = "Don Toliver",
                         TrackNumbers = 16,
                         TotalDuration = TimeSpan.Parse("1:03:08"),
                         Rating = "R"
                     },
                     new Album
                     {
                         Title = "Камнем по голове",
                         ReleaseDate = DateTime.Parse("1996-10-3"),
                         Genre = "Рок",
                         Price = 5.25M,
                         Author = "Король и Шут",
                         TrackNumbers = 21,
                         TotalDuration = TimeSpan.Parse("0:51:44"),
                         Rating = "R"
                     },
                     new Album
                     {
                         Title = "Afterlife",
                         ReleaseDate = DateTime.Parse("2023-2-23"),
                         Genre = "Rap",
                         Price = 15.0M,
                         Author = "Yeat",
                         TrackNumbers = 22,
                         TotalDuration = TimeSpan.Parse("1:07:35"),
                         Rating = "R"
                     },
                     new Album
                     {
                         Title = "EFT",
                         ReleaseDate = DateTime.Parse("2017-9-13"),
                         Genre = "Soundtrack",
                         Price = 2.11M,
                         Author = "geneburn",
                         TrackNumbers = 20,
                         TotalDuration = TimeSpan.Parse("0:59:45"),
                         Rating = "R"
                     }
                    );
                context.SaveChanges();
            }
        }
    }
}
