using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class CalculatorTest
    {
        //Naming Convetion: CLASSNAME_METHODNAME_EXPECTEDRESULT
        [Theory]
        [InlineData(4.5,25.5,30)]
        [InlineData(2.5, 25.5, 28)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void Calculator_Add_ReturnSumOfTwoNumbers(double x, double y, double expected) 
        {
            //Arrange
            //double expected = 7;

            //Act
            double actual = Calculator.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 0,0)]
        public void Divide_SimpleValueShouldDivide(double x, double y, double expected) 
        {
            // Arrange

            // Act
            double actual = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivisionShouldNotCalculateZeroDivisor() 
        {
            // Arrange
            double expected = 0;

            // Actual 
            double actual = Calculator.Divide(15, 0);

            Assert.Equal(expected, actual);
        }
    }
}
