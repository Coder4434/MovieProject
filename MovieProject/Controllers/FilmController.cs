using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Controllers
{
    public class FilmController : Controller
    {
        private static List<Film> filmler = new List<Film>();
        private const int SayfaBoyutu = 3; // Her sayfada gösterilecek film sayısı

        // Film ekleme sayfası
        public IActionResult Create()
        {
            return View();
        }

        // Film ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                film.Id = filmler.Any() ? filmler.Max(f => f.Id) + 1 : 1;
                filmler.Add(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // Filmleri listeleme
        public IActionResult Index(int sayfa = 1)
        {
            var toplamFilmSayisi = filmler.Count;
            var toplamSayfaSayisi = (int)Math.Ceiling(toplamFilmSayisi / (double)SayfaBoyutu);
            
            var sayfalanmisFilmler = filmler
                .Skip((sayfa - 1) * SayfaBoyutu)
                .Take(SayfaBoyutu)
                .ToList();

            ViewBag.ToplamSayfa = toplamSayfaSayisi;
            ViewBag.AktifSayfa = sayfa;
            ViewBag.SayfaBoyutu = SayfaBoyutu;

            return View(sayfalanmisFilmler);
        }

        // Film düzenleme sayfası (GET)
        public IActionResult Edit(int id)
        {
            var film = filmler.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // Film düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                var filmToUpdate = filmler.FirstOrDefault(f => f.Id == film.Id);
                if (filmToUpdate == null)
                {
                    return NotFound();
                }

                filmToUpdate.AdiTurkce = film.AdiTurkce;
                filmToUpdate.AdiIngilizce = film.AdiIngilizce;
                filmToUpdate.CikisTarihi = film.CikisTarihi;
                filmToUpdate.imgURL = film.imgURL;
                filmToUpdate.backimgURL = film.backimgURL;
                filmToUpdate.sure = film.sure;
                filmToUpdate.categories = film.categories;
                filmToUpdate.description = film.description;
                filmToUpdate.ImdbPuan = film.ImdbPuan;
                filmToUpdate.Oyuncular = film.Oyuncular;
                filmToUpdate.Yapimci = film.Yapimci;

                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // Film silme (GET)
        public IActionResult Delete(int id)
        {
            var film = filmler.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // Film silme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = filmler.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            filmler.Remove(film);
            return RedirectToAction(nameof(Index));
        }
    }
}
