using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore
{
    public class Tasks
    {
        /// <summary>
        /// This method is used to determine the maximum count of given integer in a sequence.
        /// </summary>
        public static void ConsecutiveIntegers()
        {
            try
            {
                //Getting input from App.config file
                var inputArrKeyValue = ConfigurationManager.AppSettings["TestConsecutive"];
                var inputArrStr = inputArrKeyValue.Split(',');

                //End function if array is empty.
                if (null == inputArrStr || inputArrStr.Length <= 0)
                {
                    Console.WriteLine("The input does not have any value;");
                    return;
                }

                #region Parsing the input as int. 
                //This is done only to read the input.
                /*-----------------------------------------------------*/
                var inputArr = new int[inputArrStr.Length];
                var counterArr = 0;

                foreach (var inputStr in inputArrStr)
                {
                    var intVal = 0;
                    int.TryParse(inputStr, out intVal);

                    inputArr[counterArr] = intVal;
                    counterArr++;
                }
                /*-----------------------------------------------------*/

                #endregion


                var inputList = inputArr.ToList();

                var previousVal = 0;
                var sameInteger = 1;
                var counter = 0;

                var sameIntegerCount = new Dictionary<int, int>();

                //Looping through the values.
                inputList.ForEach(inputVal =>
                {
                    if (counter > 0)
                    {
                        if (inputVal == previousVal) //if previous value is same as current value, then increment the counter
                        {
                            sameInteger++;
                        }
                        else //else reset the counter to 1.
                        {

                            sameInteger = 1;
                        }
                    }

                    if ((inputArr.Length > (counter + 1) && inputArr[counter + 1] != inputVal) || inputArr.Length == (counter + 1))
                    {
                        var existingCount = sameIntegerCount.FirstOrDefault(x => x.Key == inputVal);
                        var isGreater = existingCount.Value < sameInteger;

                        //Only add or update count value if current count value is greater than exsiting one for the given integer.
                        if (isGreater)
                        {
                            if (existingCount.Key != inputVal) //if count value is not present in dictionary, then add the key value pair.
                                sameIntegerCount.Add(inputVal, sameInteger);
                            else if (existingCount.Key == inputVal) //else update
                                sameIntegerCount[inputVal] = sameInteger;
                        }

                    }

                    previousVal = inputVal;

                    counter++;
                });

                Console.WriteLine("Maximun consecutive integers are as follows");
                foreach (var result in sameIntegerCount)
                {
                    Console.WriteLine("Integer: {0}  - Maximum Consecutive Count: {1}", result.Key, result.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Following error occurred during the execution of the program.");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method is used to determine whether given string is a palindrome or not.
        /// It ignores any whitespaces in the string.
        /// </summary>
        public static void CheckIfPalindromeIgnoreWhitespace()
        {
            try
            {
                var inputStr = ConfigurationManager.AppSettings["TestPalindrome"];
                var inputStrArr = inputStr.ToCharArray();

                var isPalindrome = true;
                var loopCounter = 0;

                
                for (int i = inputStrArr.Length - 1; i >= 0; i--)
                {
                    var isContinue = false;

                    //If current character at forward index is whitespace, then increment the loopCounter and index i (to repeat iteration) and continue.
                    if (loopCounter < inputStr.Length && inputStrArr[loopCounter] == ' ')
                    {
                        loopCounter++;
                        i++;
                        isContinue = true;
                    }

                    //If current character at index i is whitespace then continue, the decrement of i will be taken care of by the loop.
                    if (i < inputStr.Length && inputStrArr[i] == ' ')
                    {
                        isContinue = true;
                    }

                    if (isContinue)
                        continue;

                    //if character mismatch, then break as given input is not a palindrome.
                    if (inputStrArr[loopCounter] != inputStrArr[i])
                    {
                        isPalindrome = false;
                        break;
                    }
                    loopCounter++;
                }

                Console.WriteLine("The given input '{0}' {1} a palindrome.", inputStr, (isPalindrome ? "is" : "is not"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Following error occurred during the execution of the program.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Used to check if a given string is a palindrome or not.
        /// This method is used when whitespace is not to be ignored.
        /// The loop will have iterations upto half the length of given string.
        /// </summary>
        public static void CheckIfPalindrome()
        {
            try
            {
                var inputStr = ConfigurationManager.AppSettings["TestPalindrome"];
                var inputStrArr = inputStr.ToCharArray();

                var isPalindrome = true;
                var loopCounter = 0;

                //Determining the mid point so as to cut down the loop iterations to half
                var isLengthEven = (inputStr.Length % 2) == 0;
                var midPoint = (inputStr.Length / 2) + (isLengthEven ? 0 : 1);

                for (int i = inputStr.Length - 1; i > midPoint - 1; i--)
                {
                    //if character mismatch, then break as it is not a palindrome.
                    if (inputStrArr[loopCounter] != inputStrArr[i])
                    {
                        isPalindrome = false;
                        break;
                    }
                    loopCounter++;
                }
                Console.WriteLine("The given input '{0}' {1} a palindrome.", inputStr, (isPalindrome ? "is" : "is not"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Following error occurred during the execution of the program.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
