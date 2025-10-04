using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options):  base(options)
        {
            
        }

        public DbSet<Kurs> Kurslar => Set<Kurs>();      //bu yöntem ile Kurslar nesnesine bir başlangıç değeri atıyoruz ve nullable hatası almıyoruz.
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
    }
}