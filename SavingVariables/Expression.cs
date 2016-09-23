using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SavingVariables
{
    class Expression
    {
        public char EnteredValue_One { get; set; }
        public object EnteredValue_Two  { get; set; }
        public char EnteredOperator { get; set; }

        public string readExpression(string enteredExpression)
        {
            string[] termsArray;
            char[] operatorArray = new char[] { '=' };
            termsArray = enteredExpression.Split(operatorArray);
            var operatorValues = Regex.Matches(enteredExpression, @"/=");
            return termsArray[0];
        }

        //user input interrogation
        string userInputRegExPattern = @"^((\-?\w)\s*([\=])\s*(\-?\d+))$";
        string constantString = @"^(\s*([A-Za-z])\s*[=]\s*(\-?\d+)\s*)$";

        //method to check valid pattern and set flag
        public bool validateEnteredStringCheck(string enteredExpression)
        {
            bool returnValue = false;
            //check for valid expression
            Match match = Regex.Match(enteredExpression, userInputRegExPattern);
            if (match.Success)
            {
                returnValue = true;
                return returnValue;
            }
            //check for constant 
            match = Regex.Match(enteredExpression, constantString);
            if (match.Success)
            {
                returnValue = true;
            }
            return returnValue;
            
        }

        //if entered string was valid parse 
        //value before th operator, the operator and 
        //value after the operator and store them

        public void parseStringEntered(string enteredExpression)
        {
            //pulling out the operator
            Match match = Regex.Match(enteredExpression, userInputRegExPattern);
            char[] operatorArray = new char[] { '=' };

            if (match.Success)
            {
                var termsArray = match.Value.Split(operatorArray);
                try
                {
                    //parse the constant
                    var userInpeutBeforeOperator = char.Parse(termsArray[1]);

                    //parse the integer
                    var usertInputAfterOperator = int.Parse(termsArray[1]);

                    //set the values outside scope
                    EnteredValue_One = userInpeutBeforeOperator;
                    EnteredValue_Two = usertInputAfterOperator;

                }
                catch (Exception)
                {
                    throw new ExpressionException("incomplete string, try again");
                }
            }
            //constant check
            match = Regex.Match(enteredExpression, constantString);
            if (match.Success)
            {
                var constantArray = match.Value.Split('=');
                try
                {
                    
                    var userInputBeforeOperator = char.Parse(constantArray[0]);
                    var userInputAfterOperator = (constantArray[1]);

                    //set the values outside scope
                    EnteredValue_One = userInputBeforeOperator;
                    EnteredValue_Two = userInputAfterOperator;
                }
                catch (Exception)
                {
                    throw new ExpressionException("something was entered incorrectly.");
                }
            }
        }
    }
}
