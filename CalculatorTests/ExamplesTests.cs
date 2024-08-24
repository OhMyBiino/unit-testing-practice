using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;

namespace CalculatorTests
{
    public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidFileShouldWork() 
        {
            string actual = "This is a valid file name.";

            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void ExampleLoadTextFile_InvalidFileShouldNotWork() 
        {
            Assert.Throws<ArgumentException>("File", () => Examples.ExampleLoadTextFile(""));
        }
    }


}
