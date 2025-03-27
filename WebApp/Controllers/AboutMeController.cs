using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Indir()
        {
            var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/folders", "LaleCemileBozkurtCv.pdf");

            if (!System.IO.File.Exists(dosyaYolu))
            {
                return NotFound("Dosya bulunamadı.");
            }

            var dosyaBytes = System.IO.File.ReadAllBytes(dosyaYolu);
            return File(dosyaBytes, "application/pdf", "LaleCemileBozkurtCv.pdf");
        }
    }
}


