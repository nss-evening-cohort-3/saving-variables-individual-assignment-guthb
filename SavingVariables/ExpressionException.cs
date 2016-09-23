using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    class ExpressionException : SystemException
    {

        public ExpressionException() : base()
        {

        }

        public ExpressionException(string message) : base(message)
        {

        }


    }
}
