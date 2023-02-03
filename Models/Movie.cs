using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public string category { get; set; }
        public string description { get; set; }
    }
}
