using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SavingVariables.Models
{
    public class Constants
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Char ConstantName { get; set; }

        [Required]
        public int Varible { get; set; }



    }
}
