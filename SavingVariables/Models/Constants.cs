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
        [MaxLength (length: 1)]
        public string ConstantName { get; set; }

        [Required]
        public int Varible { get; set; }

        public override string ToString()
        {
            return ConstantName + " -> " + Varible;
        }

        
    }

    public static class ConstantsExtentionMethods
    {
        public static string ConstantListToString(this List<Constants> my_list_constants)
        {
           var myListString = my_list_constants.Select(constants => constants.ToString());
            return string.Join(System.Environment.NewLine, myListString);
        }

    }


}
