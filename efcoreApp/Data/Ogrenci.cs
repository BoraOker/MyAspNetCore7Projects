namespace efcoreApp.Data {

    public class Ogrenci {

        // OgrenciId veya Id 'den baska bişey yazarsan [Key] keyword eklenmeli.
        public int OgrenciId { get; set; }
        public string? OgrenciAdi { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string AdSoyad { 
            get{
                return this.OgrenciAdi + " " + this.OgrenciSoyad;
            } }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();     // Her bir öğrenci birden fazla kurs kaydına sahip olabileceği için sahip olduğu kurs kayıtlarının hepsini ICollection ile alabiliriz.
    }

















}