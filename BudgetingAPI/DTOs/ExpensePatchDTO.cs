using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetingAPI.DTOs{


    public class ExpensePatchDTO
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]  //Two decimal points.
        [Range(0, 9999999999999999.99)]         //Min 0(non negative), Max 18 digits.
        [Column(TypeName = "decimal(18,2)")]   //up to 18 digits, 2 dp
        public decimal Amount {get; set;}
    }
}