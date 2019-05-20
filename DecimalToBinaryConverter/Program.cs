using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinaryConverter
{
    public class IntegerConvertToBinary
    {
        public decimal userNumber { get; set; }
        public int integerPortionOfUserNumber { get; set; }
        public decimal fractionalPortionOfUserNumber { get; set; }
        public int IntegerPortionOfUserNumberConvertedToBinary { get; set; }
        //public List<int> ListOfDivisionResults = new List<int>();

        public List<int> ListOfResultsFromConvertIntegerPortionToBinary = new List<int>();
        public List<int> ListOfResultsFromConvertFractionalPortionToBinary = new List<int>();

        static void Main(string[] args)
        {
            IntegerConvertToBinary integerConvertToBinary = new IntegerConvertToBinary();
            Console.WriteLine("Please enter a decimal to convert it to binary");
            integerConvertToBinary.userNumber = Convert.ToDecimal(Console.ReadLine());
            //TODO: write a method of catching inappropriate input
        }
        
        public void SeparateIntegerAndFractionalPortionsOfUserNumber()
        {
            integerPortionOfUserNumber = (int)userNumber;
            fractionalPortionOfUserNumber = userNumber - integerPortionOfUserNumber;
        }

        public void ConvertIntegerPortionOfUserNumberToBinary()
        {
            do
            {
                ListOfResultsFromConvertIntegerPortionToBinary.Insert(0, integerPortionOfUserNumber % 2);
                integerPortionOfUserNumber /= 2;
            } while (integerPortionOfUserNumber != 0);

            AppendListOfIntsIntoASingleValue(ListOfResultsFromConvertIntegerPortionToBinary);
        }

        public int AppendListOfIntsIntoASingleValue(List<int> ListOfDivisionResults)
        {
            string AppendationOfListElements = "";

            for (int i = 0; i < ListOfDivisionResults.Count; i++)
            {
                AppendationOfListElements += $"{ListOfDivisionResults[i]}";
            }

            return Convert.ToInt32(AppendationOfListElements);
        }
        //TODO: Add method for ConvertFractionalPortionOfUserNumberToBinary

    }
}
