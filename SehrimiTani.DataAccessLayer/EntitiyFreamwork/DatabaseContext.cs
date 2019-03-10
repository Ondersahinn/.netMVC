using SehrimiTani.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.DataAccessLayer.EntitiyFreamwork
{
    public class DatabaseContext : DbContext
    {
        

        public DbSet<Kullanicilar> Kullanici { get; set; }
        public DbSet<Barinma> Barinmlar { get; set; }
        public DbSet<Gezilecekyer> Gezilecekyerler { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DbSet<Sehirler> Sehir { get; set; }
        public DbSet<Universite> Universiteler { get; set; }
        public DbSet<Yemekler> Yemek { get; set; }
        public DbSet<Yorumlar> Yorum { get; set; }
        public DbSet<Puan> puanlar { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }


    }
}
