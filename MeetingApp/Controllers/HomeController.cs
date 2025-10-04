using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller {

        public IActionResult Index() {

            int saat = DateTime.Now.Hour;
            // int saat = 18;
            // var selamlama = saat > 17 ? "İyi Akşamlar":"İyi Günler";

            // ViewBag.Selamlama = saat > 17 ? "İyi Akşamlar":"İyi Günler";
            // ViewBag.Username = "Bora";

            ViewData["Selamlama"] = saat > 17 ? "İyi Akşamlar":"İyi Günler";
            // ViewData["Username"] = "Bora";

            int UserCount = Repository.Users.Where(info=> info.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo() {
                Id=1,
                Location="Konya,Selçuklu Kongre Merkezi",
                Date = new DateTime(2024,10,04,20,0,0),
                NumberOfPeople = UserCount
            };
            return View(/*model : selamlama*/meetingInfo);
        }
    }
}