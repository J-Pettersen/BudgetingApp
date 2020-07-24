using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetingAPI.Models{


    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name="Expense")]
        public string Type { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } 

        [Required]
        public bool Outgoings { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]  //Two decimal points.
        [Range(0, 9999999999999999.99)]         //Min 0(non negative), Max 18 digits.
        [Column(TypeName = "decimal(18,2)")]   //up to 18 digits, 2 dp
        public decimal Amount {get; set;}

        [Required]
        public DateTime Date { get; set; }
    }
}