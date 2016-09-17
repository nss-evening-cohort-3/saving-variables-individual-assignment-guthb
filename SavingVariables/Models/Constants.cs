using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SavingVariables.Models
{
    class Constants
    {
        [Key]
        public String ConstantName { get; set; }

        [Required]
        public int Varible { get; set; }



    }
}
