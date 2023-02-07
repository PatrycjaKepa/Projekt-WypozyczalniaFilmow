using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_WypozyczalniaFilmow.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Movie name cannot be longer than 50 characters.")]
        public string Name { get; set; }
    }
}


