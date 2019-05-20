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
    public class IntegerConvertToBinaryTests
    {
        [TestMethod()]
        public void SeparateIntegerAndFractionalPortionsOfUserNumberTest()
        {
            //Arrange
            IntegerConvertToBinary integerConvertToBinary = new IntegerConvertToBinary();
            integerConvertToBinary.userNumber = 3.1415M;
            //Act
            integerConvertToBinary.integerPortionOfUserNumber = (int)integerConvertToBinary.userNumber;
            integerConvertToBinary.fractionalPortionOfUserNumber = integerConvertToBinary.userNumber - integerConvertToBinary.integerPortionOfUserNumber;
            //Assert
            Assert.AreEqual(3, integerConvertToBinary.integerPortionOfUserNumber);
            Assert.AreEqual(.1415M, integerConvertToBinary.fractionalPortionOfUserNumber);
        }

        [TestMethod()]
        public void ConvertIntegerPortionOfUserNumberToBinaryTest()
        {
            //Arrange
            IntegerConvertToBinary integerConvertToBinary = new IntegerConvertToBinary();
            List<int> ListOfDivisionResults = new List<int>();
            integerConvertToBinary.integerPortionOfUserNumber = 3;
            string AppendationOfListElements = "";

            //Act
            do
            {
                ListOfDivisionResults.Insert(0, integerConvertToBinary.integerPortionOfUserNumber % 2);
                integerConvertToBinary.integerPortionOfUserNumber /= 2;
            } while (integerConvertToBinary.integerPortionOfUserNumber != 0);

            
            //Assert
            Assert.AreEqual(1, ListOfDivisionResults[0]);
            Assert.AreEqual(1, ListOfDivisionResults[1]);
            Assert.AreEqual(2, ListOfDivisionResults.Count);
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

            int thisWouldBeTheReturnVariable = Convert.ToInt32(AppendationOfListElements);

            //Assert
            Assert.AreEqual("112", AppendationOfListElements);
            Assert.AreEqual(112, thisWouldBeTheReturnVariable);
        }
    }
}