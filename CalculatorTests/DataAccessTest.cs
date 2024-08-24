using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;

namespace CalculatorTests
{
    public class DataAccessTest
    {
        [Fact]
        public void AddNewPerson_AddPersonToTheList()
        {
            // Arrange
            List<PersonModel> people = new List<PersonModel>();
            PersonModel newPerson = new PersonModel() { FirstName = "Daven", LastName = "Arzobal" };

            // Actual
            DataAccess.AddNewPerson(people, newPerson);

            // Assert
            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        //Create a test that will fail if given firstname/lastname was an invalid
        [Theory]
        [InlineData("Daven", "", "Lastname")]
        [InlineData("", "Arzobal", "Firstname")]
        public void AddNewPerson_PersonWithInvalidNameShouldFail(string firstname, string lastname, string param)
        {
            // Arrange
            List<PersonModel> people = new List<PersonModel>();
            PersonModel newPerson = new PersonModel() { FirstName = firstname, LastName = lastname };

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddNewPerson(people, newPerson));
        }

        [Fact]
        public void ConvertModelToCSV_ShouldAddPeopleToStringList()
        {
            // Arrange
            List<PersonModel> people = new List<PersonModel>();
            people.Add(new PersonModel() { FirstName = "Daven", LastName = "Arzobal" });
            people.Add(new PersonModel() { FirstName = "John", LastName = "Doe"});

            // Actual
            List<string> actual = DataAccess.ConvertModelToCSV(people);

            // Assert
            Assert.True(actual.Count == 2);
            Assert.Equal("Daven,Arzobal", actual[0]);
            Assert.Equal("John,Doe", actual[1]);
        }

        [Fact]
        public void SplitPeopleNameIntoTwo_ShouldSplitPersonModelNameToTwo() 
        {
            //Arrange
            string[] contents = new string[] 
            {
                "Daven,Arzobal",
                "Mark,Daven"
            };

            //Act
            List<PersonModel> expected = DataAccess.SplitPeopleNameIntoTwo(contents);

            //Assert
            Assert.Equal("Daven", expected[0].FirstName);
            Assert.Equal("Arzobal", expected[0].LastName);
            Assert.Equal("Mark", expected[1].FirstName);
            Assert.Equal("Daven", expected[1].LastName);
        }

        [Fact]
        public void SplitPeopleNameIntoTwo_ShouldReturnEmptyListWithEmptyArrayInput() 
        {
            // Arrange
            string[] input = new string[] { };

            //Act
            var actual = DataAccess.SplitPeopleNameIntoTwo(input);

            //Assert
            Assert.Empty(actual);
        }
    }
}
