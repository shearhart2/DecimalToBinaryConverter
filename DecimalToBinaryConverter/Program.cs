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
            List<int> ConversionResults = new List<int>();

            do
            {
                ConversionResults.Insert(0, integerPortionOfUserNumber % 2);
                integerPortionOfUserNumber /= 2;
            } while (integerPortionOfUserNumber != 0);
            //TODO: This should be all you need for the integer portion of the conversion, but go back over it before continuing
        }
        //TODO: Add method for ConvertFractionalPortionOfUserNumberToBinary
    }
}
