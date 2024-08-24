using DemoLibrary.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class DataAccess
    {
        private static string personTextFile = "PersonText.txt";

        public void AddNewPerson(PersonModel person) 
        {
           
            List<PersonModel> people = GetAllPerson();

            AddNewPerson(people, person);

            List<string> lines = ConvertModelToCSV(people);

            File.WriteAllLines(personTextFile, lines);
        }

        public static void AddNewPerson(List<PersonModel> people, PersonModel person) 
        {
            if (string.IsNullOrWhiteSpace(person.FirstName)) 
            {
                throw new ArgumentException("Invalid first name.", "Firstname");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Invalid first name.", "Lastname");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelToCSV(List<PersonModel> people) 
        {
            List<string> output = new List<string>();

            foreach (PersonModel user in people) 
            {
                output.Add($"{user.FirstName},{user.LastName}");
            }

            return output;
        }

        public static List<PersonModel> GetAllPerson() 
        {
           
            string[] contents = File.ReadAllLines(personTextFile);

            List<PersonModel> output = SplitPeopleNameIntoTwo(contents);

            return output;
        }

        public static List<PersonModel> SplitPeopleNameIntoTwo(string[] contents)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string lines in contents)
            {
                string[] data = lines.Split(',');
                output.Add(new PersonModel() { FirstName = data[0], LastName = data[1] });
            }

            return output;
        }

    }
}
