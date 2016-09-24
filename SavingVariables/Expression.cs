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
        public string EnteredValue_One { get; set; }
        public int EnteredValue_Two  { get; set; }
        public char EnteredOperator { get; set; }

        public Stack my_Stack = new Stack();

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
        string singleConstant = @"^([A-Za-z])$";
        string clearSingleConstant = @"(?<=clear\s)[A-Za-z]$";
        string showAllConstants = @"(?<=)ow\sall$";
        string clearAllConstants = @"(?$";

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

        public string parseStringEntered(string enteredExpression)
        {
            //pulling out the operator
            Match match = Regex.Match(enteredExpression, userInputRegExPattern);
            char[] operatorArray = new char[] { '=' };
            string returnValue;

            if (match.Success)
            {
                var termsArray = match.Value.Split(operatorArray);
                try
                {
                    //parse the constant
                    var userInpeutBeforeOperator = (termsArray[1]);

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
                    var userInputBeforeOperator = (constantArray[0]);
                    var userInputAfterOperator = int.Parse(constantArray[1]);

                    //set the values outside scope
                    EnteredValue_One = userInputBeforeOperator;
                    EnteredValue_Two = userInputAfterOperator;
                    my_Stack.AddConstant(EnteredValue_One, EnteredValue_Two);
                    returnValue = "saved " + EnteredValue_One + " as " + EnteredValue_Two;
                    return returnValue;
                }
                catch (Exception exp)
                {
                    return exp.Message;
                }
            }
            match = Regex.Match(enteredExpression, singleConstant);
            if (match.Success)
            {
              returnValue = " = " + my_Stack.FindConstant(match.Value).ToString();
              return returnValue;
            }

            match = Regex.Match(enteredExpression, clearSingleConstant);
            if (match.Success)
            {
                try
                {
                    returnValue = my_Stack.RemoveConstant(match.Value).ToString() + " is now free!";
                    return returnValue;
                }
                catch (Exception exp)
                {
                    return exp.Message;
                }
            }
            match = Regex.Match(enteredExpression, showAllConstants);
            if (match.Success)    
            {
                try
                {
                    return my_Stack.ShowConstants(enteredExpression).ToString();
                    
                }
                catch (Exception exp)
                {
                    return exp.Message;
                }
            }

            return "something was entered incorrectly!!";
        }
    }
}
