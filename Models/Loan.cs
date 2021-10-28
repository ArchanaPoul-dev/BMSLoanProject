using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BMSLoanService.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string RegId { get; set; }
        [Required]
        [StringLength(5)]
        public string loantype { get; set; }
        public int loanamt { get; set; }
        public System.DateTime loanapplydate { get; set; }
        public System.DateTime loanissuedate { get; set; }
        public int roi { get; set; }
        public Nullable<int> coursefees { get; set; }

        [StringLength(50)]
        public string course { get; set; }

        [StringLength(50)]
        public string fathername { get; set; }
        public Nullable<int> fatherexp { get; set; }
        public Nullable<int> fexpcurrentcmpny { get; set; }
        public string rationcardno { get; set; }
        public Nullable<int> annualincome { get; set; }

        [StringLength(50)]
        public string companyname { get; set; }

        [StringLength(50)]
        public string designation { get; set; }
        public Nullable<int> totalexp { get; set; }
        public Nullable<int> expwithcurcmpny { get; set; }


    }
}
