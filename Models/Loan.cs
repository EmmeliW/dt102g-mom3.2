using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EFprojekt.Models
{
    public class Loans
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Datum för utlån")]
        public DateTime? LoanDate { get; set; } = DateTime.Today;
 
        [DisplayName("Låntagerans namn")]
        [MinLength(3, ErrorMessage = "Ditt namn måste innehålla minst tre tecken.")]
        [Required(ErrorMessage = "Du måste ange ditt namn!")]
        public String Name { get; set; }

        [DisplayName("Skivans titel")]
        [MinLength(3, ErrorMessage = "Skivtiteln måste innehålla minst tre tecken.")]
        //[Required(ErrorMessage = "Du måste ange titel på skivan!")]
        [ForeignKey("RecordName")]     
        public String RecordName { get; set; }
        public Records Record { get; set; }
    }
}
