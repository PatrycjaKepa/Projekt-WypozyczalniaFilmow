using System.ComponentModel.DataAnnotations;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class Lend
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RentDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public decimal Price { get; set; }

        //[Required]
        //[DefaultValue((int)LendStatus.Rented)]
        public LendStatus lendStatus { get; set; }

        public bool isRented()
        {
            return this.lendStatus == LendStatus.Rented;
        }
    }
}
