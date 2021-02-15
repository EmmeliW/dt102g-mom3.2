using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFprojekt.Models
{
    public class Records
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Artist")]
        [MinLength(3, ErrorMessage = "Artistens namn måste innehålla minst tre tecken.")]
        [Required(ErrorMessage = "Du måste ange artist!")]
        public string Artist { get; set; }

        [DisplayName("Skivans titel")]
        [MinLength(3, ErrorMessage = "Skivtiteln måste innehålla minst tre tecken.")]
        [Required(ErrorMessage = "Du måste ange namnet på skivan!")]
        public string Title { get; set; }

        // FK
        [Required]
        [DisplayName("Genre")]
        public string RecordGenre { get; set; }
        public Genres Genre { get; set; }
    }
} 