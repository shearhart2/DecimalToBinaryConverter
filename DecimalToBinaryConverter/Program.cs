using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinaryConverter
{
    public class DecimalConvertToBinary
    {
        public decimal UserNumber { get; set; }
        public int IntegerPortionOfUserNumber { get; set; }
        public decimal FractionalPortionOfUserNumber { get; set; }
        public string IntegerPortionOfUserNumberConvertedToBinaryString { get; set; }
        public string FractionalPortionOfUserNumberConvertedToBinaryString { get; set; }

        public List<int> ListOfResultsFromConvertIntegerPortionToBinary = new List<int>();
        public List<int> ListOfResultsFromConvertFractionalPortionToBinary = new List<int>();

        static void Main(string[] args)
        {
            DecimalConvertToBinary decimalConvertToBinary = new DecimalConvertToBinary();
            Console.WriteLine("Please enter a decimal to convert it to binary");
            decimalConvertToBinary.UserNumber = Convert.ToDecimal(Console.ReadLine());
            //TODO: write a method of catching inappropriate input
            decimalConvertToBinary.SeparateIntegerAndFractionalPortionsOfUserNumber();
            decimalConvertToBinary.ConvertIntegerPortionOfUserNumberToBinary();
            decimalConvertToBinary.ConvertFractionalPortionOfUserNumberToBinary();
            decimalConvertToBinary.CombineIntegerAndFractionalResultsIntoASingleBinaryNumber();
        }
        
        public void SeparateIntegerAndFractionalPortionsOfUserNumber()
        {
            IntegerPortionOfUserNumber = (int)UserNumber;
            FractionalPortionOfUserNumber = UserNumber - IntegerPortionOfUserNumber;
        }

        public void ConvertIntegerPortionOfUserNumberToBinary()
        {
            do
            {
                ListOfResultsFromConvertIntegerPortionToBinary.Insert(0, IntegerPortionOfUserNumber % 2);
                IntegerPortionOfUserNumber /= 2;
            } while (IntegerPortionOfUserNumber != 0);

            IntegerPortionOfUserNumberConvertedToBinaryString = AppendListOfIntsIntoASingleValue(ListOfResultsFromConvertIntegerPortionToBinary);
        }

        public void ConvertFractionalPortionOfUserNumberToBinary()
        {
            List<decimal> PreviousValuesOfFractionalPortionOfUserNumber = new List<decimal>();
            
            do
            {
                FractionalPortionOfUserNumber = decimal.Multiply(FractionalPortionOfUserNumber, 2M);

                if (PreviousValuesOfFractionalPortionOfUserNumber.Contains(FractionalPortionOfUserNumber))
                {
                    break;
                }
                else if(FractionalPortionOfUserNumber >= 1M)
                {
                    ListOfResultsFromConvertFractionalPortionToBinary.Add(1);
                    FractionalPortionOfUserNumber -= 1M;
                }
                else
                {
                    ListOfResultsFromConvertFractionalPortionToBinary.Add(0);
                }

                PreviousValuesOfFractionalPortionOfUserNumber.Add(FractionalPortionOfUserNumber);

            } while (true);

            
            FractionalPortionOfUserNumberConvertedToBinaryString = AppendListOfIntsIntoASingleValue(ListOfResultsFromConvertFractionalPortionToBinary);
        }

        public string AppendListOfIntsIntoASingleValue(List<int> ListOfDivisionResults)
        {
            string AppendationOfListElements = "";

            for (int i = 0; i < ListOfDivisionResults.Count; i++)
            {
                AppendationOfListElements += $"{ListOfDivisionResults[i]}";
            }

            return AppendationOfListElements;
        }

        public void CombineIntegerAndFractionalResultsIntoASingleBinaryNumber()
        {
            string AppendationOfIntegerAndFraction = $"{IntegerPortionOfUserNumberConvertedToBinaryString}.{FractionalPortionOfUserNumberConvertedToBinaryString}";
            decimal FinalBinaryNumber = Convert.ToDecimal(AppendationOfIntegerAndFraction);
            Console.WriteLine(FinalBinaryNumber);
        }
    }
}
