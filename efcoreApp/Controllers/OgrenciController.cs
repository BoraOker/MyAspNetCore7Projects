using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgrenciController : Controller {

        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Ogrenciler.ToListAsync());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model) {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Ogrenci");
        }

        public async Task<IActionResult> Edit(int? id) {
            if(id == null) {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.Include(x => x.KursKayitlari).ThenInclude(o => o.Kurs).FirstOrDefaultAsync(o => o.OgrenciId == id);  
            // ThenInclude: Ulaştığımız KursKayitlari tablosundan da Kurs tablosuna ulaşmak istediğimiz için bu methodu kullanmalıyız.  
            // Doğrudan id bilgisine göre arama yapan method = FindAsync();
            // var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciId == id);     FirstOrDefaultAsync methodu ile id'den başka değerler ile de arama yapılabilir.

            if(ogr == null) {
                return NotFound();
            }

            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]     // Asp.net in kendi oluşturduğu formu oluşturan kişiyle post eden kişinin aynı olmasını kontrol eden token validasyonu
        public async Task<IActionResult> Edit(int id, Ogrenci model) {
            if(id != model.OgrenciId) {
                return NotFound();
            }

            if(ModelState.IsValid) {
                try {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException) {       // Güncelleme esnasında güncelleme yapılan verinin silinmiş olması
                    if(!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction("Index","Ogrenci");
            }

            return View(model);
        }  


        public async Task<IActionResult> Delete(int? id) {
            if(id == null) {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if(ogrenci == null) {
                return NotFound();
            }

            return View(ogrenci);
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id) {     // Formdan gelen id bilgisini almak (ayır etmek) için bunu yazdık.
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null) {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}