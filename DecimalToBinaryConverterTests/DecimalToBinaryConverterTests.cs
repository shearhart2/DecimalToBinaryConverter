using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecimalToBinaryConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DecimalToBinaryConverter.Tests
{
    [TestClass()]
    public class DecimalConvertToBinaryTests
    {
        [TestMethod()]
        public void SeparateIntegerAndFractionalPortionsOfUserNumberTest()
        {
            //Arrange
            DecimalConvertToBinary decimalConvertToBinary = new DecimalConvertToBinary();
            decimalConvertToBinary.UserNumber = 3.1415M;
            //Act
            decimalConvertToBinary.IntegerPortionOfUserNumber = (int)decimalConvertToBinary.UserNumber;
            decimalConvertToBinary.FractionalPortionOfUserNumber = decimalConvertToBinary.UserNumber - decimalConvertToBinary.IntegerPortionOfUserNumber;
            //Assert
            Assert.AreEqual(3, decimalConvertToBinary.IntegerPortionOfUserNumber);
            Assert.AreEqual(.1415M, decimalConvertToBinary.FractionalPortionOfUserNumber);
        }

        [TestMethod()]
        public void ConvertIntegerPortionOfUserNumberToBinaryTest()
        {
            //Arrange
            DecimalConvertToBinary decimalConvertToBinary = new DecimalConvertToBinary();
            List<int> ListOfDivisionResults = new List<int>();
            decimalConvertToBinary.IntegerPortionOfUserNumber = 3;
            //Act
            do
            {
                ListOfDivisionResults.Insert(0, decimalConvertToBinary.IntegerPortionOfUserNumber % 2);
                decimalConvertToBinary.IntegerPortionOfUserNumber /= 2;
            } while (decimalConvertToBinary.IntegerPortionOfUserNumber != 0);


            //Assert
            Assert.AreEqual(1, ListOfDivisionResults[0]);
            Assert.AreEqual(1, ListOfDivisionResults[1]);
            Assert.AreEqual(2, ListOfDivisionResults.Count);
        }


        [TestMethod()]
        public void ConvertFractionalPortionOfUserNumberToBinaryTest()
        {
            //Arrange
            DecimalConvertToBinary integerConvertToBinary = new DecimalConvertToBinary();
            decimal FractionalPortionOfUserNumber = .14M;
            List<int> ListOfResultsFromConvertFractionalPortionToBinary = new List<int>();
            List<decimal> PreviousValuesOfFractionalPortionOfUserNumber = new List<decimal>();

            //Act
            do
            {
                FractionalPortionOfUserNumber = decimal.Multiply(FractionalPortionOfUserNumber, 2M);

                if (PreviousValuesOfFractionalPortionOfUserNumber.Contains(FractionalPortionOfUserNumber))
                {
                    break;
                }
                else if (FractionalPortionOfUserNumber >= 1M)
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

            //Assert
            Assert.AreEqual(0, ListOfResultsFromConvertFractionalPortionToBinary[0]);
            Assert.AreEqual(0, ListOfResultsFromConvertFractionalPortionToBinary[1]);
            Assert.AreEqual(1, ListOfResultsFromConvertFractionalPortionToBinary[2]);
            Assert.AreEqual(1, ListOfResultsFromConvertFractionalPortionToBinary[11]);
            Assert.AreEqual(21, ListOfResultsFromConvertFractionalPortionToBinary.Count);
        }

        [TestMethod()]
        public void AppendListOfIntsIntoASingleValueTest()
        {
            //Arrange
            List<int> ListOfDivisionResults = new List<int>() { 1, 1, 2 };
            string AppendationOfListElements = "";

            //Act

            for (int i = 0; i < ListOfDivisionResults.Count; i++)
            {
                AppendationOfListElements += $"{ListOfDivisionResults[i]}";
            }
            //Assert
            Assert.AreEqual("112", AppendationOfListElements);
        }

        [TestMethod()]

        public void CombineIntegerAndFractionalResultsIntoASingleBinaryNumber()
        {
            //Arrange
            string integer = "11";
            string fraction = "001000111101011100001";
            //Act
            string AppendationOfIntegerAndFraction = $"{integer}.{fraction}";
            decimal FinalBinaryNumber = Convert.ToDecimal(AppendationOfIntegerAndFraction);

            //Assert
            Assert.AreEqual("11.001000111101011100001", AppendationOfIntegerAndFraction);
            Assert.AreEqual(11.001000111101011100001M, FinalBinaryNumber);
        }
    }
}