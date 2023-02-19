using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Movie name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }
        
        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters.")]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CategoryDropdownList { get; set; }
        public Movie()
        {
            this.Categories = new HashSet<Category>();
        }

        public string ToString()
        {
            return Name;
        }
    }
}
