using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace EFprojekt.Models
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }

        [DisplayName("Genre")]
        [MinLength(3, ErrorMessage = "Genren måste innehålla minst tre tecken.")]
        [Required(ErrorMessage = "Du måste genre på skivan!")]
        public string GenreName { get; set; }
    }
}