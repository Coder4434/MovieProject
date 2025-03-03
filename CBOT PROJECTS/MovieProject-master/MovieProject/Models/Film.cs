using System;

namespace MovieProject.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string AdiTurkce { get; set; }
        public string AdiIngilizce { get; set; }
        public DateTime CikisTarihi { get; set; }
        public string imgURL { get; set; }
        public string backimgURL { get; set; }
        public string sure { get; set; }
        public string categories { get; set; }
        public string description { get; set; }
        //public double ImdbPuan { get; set; }
        public decimal ImdbPuan { get; set; }
        public string Oyuncular { get; set; }
        public string Yapimci { get; set; }
    }
}
