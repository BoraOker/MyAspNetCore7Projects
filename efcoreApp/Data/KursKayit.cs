using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class KursKayit {

        [Key]
        public int KayitId { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!;   // Navigation Properties: EF sayesinde bu şekilde yazarak tablolardan join işlemi yapıyoruz.
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
        public DateTime KayitTarihi { get; set; }
    }
}