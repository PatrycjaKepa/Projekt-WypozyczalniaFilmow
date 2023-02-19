using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class User 
    {
        
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)] 
        public DateTime Birthdate { get; set; }
        [StringLength(70, ErrorMessage = "First name cannot be longer than 70 characters.")]
        public string Email { get; set; }
        [StringLength(30, ErrorMessage = "First name cannot be longer than 30 characters.")]
        
        public string Password { get; set; }

        [Required]
        [DefaultValue((int)PermissionRole.User)]
        public PermissionRole Role { get; set; }

        public ICollection<Lend> Lends { get; set; }

        public string ToString()
        {
            return FirstName;
        }
    }
}
