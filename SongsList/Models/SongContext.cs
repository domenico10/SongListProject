using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class SongContext : DbContext //DBCONTEXT IS A LINK BETWEEN DATABASE AND WEBPAGE
    {
        public SongContext(DbContextOptions<SongContext> options) //CONTRACTOR OF SONG CONTEXT PASSING DBCONTEXTOPTION AS PARAMETER AND THE LIST OF SONGCONTEXT AND NAMED AS 'OPTIONS'
            : base(options) //CONFIGURATION PASSING OPTION IN BASE CLASS
        {
        }

        public DbSet<Song> Songs { get; set; } //LIST OF SONGS
        public DbSet<Genre> Genres { get; set; } //LIST OF SONGS
        protected override void OnModelCreating(ModelBuilder modelBuilder) //CALLED BY THE FRAMEWORK WHEN THE CONTEXT IS CREATED.. CLASS MODELBUILDER PROVIDES AN API SERVICE TO CONFIGURE THE ENTITY FRAMEWORK METADATA(ASSIGN VALUES TO FIELDS IN DB)
        {
            modelBuilder.Entity<Genre>().HasData( //ADD ENTITY FOR THE SONGS. ADD DATA USING HAS DATA() CONFIGURES THIS ENTITY TO SEED THE DB
                new Genre { GenreId = "M", Name = "Metal" },
                new Genre { GenreId = "R", Name = "Rap" },
                new Genre { GenreId = "H", Name = "Hip Pop" },
                new Genre { GenreId = "RC", Name = "Rock" }
                );

            modelBuilder.Entity<Song>().HasData( //ADD ENTITY FOR THE SONGS. ADD DATA USING HAS DATA() CONFIGURES THIS ENTITY TO SEED THE DB
                new Song //DATA
                {
                    SongId = 1,
                    Name = "Master of Puppets",
                    Year = 1980,
                    Rating = 5,
                    GenreId = "M",
                },
                new Song //DATA
                {
                    SongId = 2,
                    Name = "Wonderwall",
                    Year = 1990,
                    Rating = 4,
                    GenreId = "RC",
                },
                new Song //DATA
                {
                    SongId = 3,
                    Name = "Lose Yourself",
                    Year = 2005,
                    Rating = 1,
                    GenreId = "R",
                }
                );
        }

    }
}
