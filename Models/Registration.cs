using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService.Models
{
    public class Registration
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string GaurdianType { get; set; }
        [Required]
        [StringLength(50)]
        public string GaurdianName { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Citizenship { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> State { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(5)]
        public string Gender { get; set; }
        [Required]
        [StringLength(5)]
        public string MaritalStatus { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactNo { get; set; }
        public System.DateTime DOB { get; set; }
        public System.DateTime RegDate { get; set; }

        [Required]
        [StringLength(5)]
        public string AccountType { get; set; }
        [Required]
        [StringLength(50)]
        public string CitizenStatus { get; set; }

        public Nullable<int> InitialDepAmt { get; set; }
        [Required]
        [StringLength(5)]
        public string IDProofType { get; set; }
        [Required]
        [StringLength(50)]
        public string IDDocNo { get; set; }

        [Required]
        [StringLength(50)]
        public string RefAccholderName { get; set; }
        [Required]
        [StringLength(50)]
        public string RefAccholderNo { get; set; }
        [Required]
        [StringLength(50)]
        public string RefAccholderAddress { get; set; }
        

    }
}
