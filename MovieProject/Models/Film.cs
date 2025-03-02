using System;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string AdiTurkce { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string AdiIngilizce { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2030-12-31", ErrorMessage = "Tarih 1900 ile 2030 arasında olmalıdır.")]
        public DateTime CikisTarihi { get; set; }

        [Required, Url(ErrorMessage = "Geçerli bir URL girin.")]
        public string imgURL { get; set; }

        [Required, Url(ErrorMessage = "Geçerli bir URL girin.")]
        public string backimgURL { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Film süresi 1 ile 500 dakika arasında olmalıdır.")]
        public int sure { get; set; }

        [Required, MinLength(3, ErrorMessage = "Kategori en az 3 karakter olmalıdır.")]
        public string categories { get; set; }

        [Required, MinLength(10, ErrorMessage = "Açıklama en az 10 karakter içermelidir.")]
        public string description { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "IMDb puanı 0 ile 10 arasında olmalıdır.")]
        public double ImdbPuan { get; set; }

        [Required, MinLength(3)]
        public string Oyuncular { get; set; }

        [Required, MinLength(3)]
        public string Yapimci { get; set; }
    }
}
