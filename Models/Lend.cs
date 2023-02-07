using System.ComponentModel.DataAnnotations;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class Lend
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string MovieName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RentDate { get; set; }
        public int HowMuchWeeks { get; set; }
        public string BeingLate { get; set; }
    }
}
