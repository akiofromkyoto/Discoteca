using Discoteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Discoteca.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)  
        { 
            
        }

        public DbSet<MusicModel> Musics { get; set; }
    }
}
