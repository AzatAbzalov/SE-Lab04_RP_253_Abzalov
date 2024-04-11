using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE_Lab04_RP_253_Abzalov.Models;

namespace SE_Lab04_RP_253_Abzalov.Data
{
    public class SE_Lab04_RP_253_AbzalovContext : DbContext
    {
        public SE_Lab04_RP_253_AbzalovContext (DbContextOptions<SE_Lab04_RP_253_AbzalovContext> options)
            : base(options)
        {
        }

        public DbSet<SE_Lab04_RP_253_Abzalov.Models.Album> Album { get; set; } = default!;
    }
}
