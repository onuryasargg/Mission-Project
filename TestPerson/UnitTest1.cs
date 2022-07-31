using Mission_Project.Models;
using Mission_Project.Controllers;

namespace TestPerson
{
    public class PersonValidationTest
    {
        Person person = new Person();
        HomeController home = new HomeController();
        bool confirmed;
        double percentageOfTechnologies = 0;

        [Fact]
        public void Percentage_Of_Technologies_Test()
        {
            // Arrange

            var technologies = new List<Technology>(){
            new Technology { Value = 1, Text = "C#", IsChecked = true },
            new Technology { Value = 1, Text = "MSSQL", IsChecked = true },
            new Technology { Value = 1, Text = "JS", IsChecked = false },
            new Technology { Value = 1, Text = "MSSQL", IsChecked = false },
            new Technology { Value = 1, Text = "ALGORITHM", IsChecked = false },
            new Technology { Value = 1, Text = "DATA STRUCTURE", IsChecked = false }};

            // Act

            percentageOfTechnologies = home.PercentageOfTechnologies(technologies);

            // Assert

            Assert.Equal(percentageOfTechnologies, 33.33333333333334);
        }
        [Fact]
        public void Calculate_Identification_Test()
        {
            // Arrange

            long IdentificationNumber = 10000000146;

            // Act

            confirmed = home.CalculateIdentification(IdentificationNumber);

            // Assert

            Assert.Equal(confirmed, true);
        }
        [Fact]
        public void ResultA_Test()
        {
            // Arrange

            person.Age = 17;
            percentageOfTechnologies = 20;
            confirmed = false;
            person.Experience = 0;

            // Act

            string result = home.Result(person, percentageOfTechnologies, confirmed);

            // Assert

            Assert.Equal(result, "AutoRejected");
        }
        [Fact]
        public void ResultB_Test()
        {
            // Arrange 

            person.Age = 16;
            percentageOfTechnologies = 25;
            confirmed = true;
            person.Experience = 0;

            // Act

            string result = home.Result(person, percentageOfTechnologies, confirmed);

            // Assert

            Assert.Equal(result, "TransferredToHR");
        }
        [Fact]
        public void ResultC_Test()
        {
            // Arrange

            person.Age = 24;
            percentageOfTechnologies = 80;
            confirmed = true;
            person.Experience = 2;

            // Act

            string result = home.Result(person, percentageOfTechnologies, confirmed);

            // Assert

            Assert.Equal(result, "AutoAccepted");
        }
        [Fact]
        public void ResultD_Test()
        {
            // Arrange

            percentageOfTechnologies = 40;
            person.Experience = 2;

            // Act

            var result = home.Result(person, percentageOfTechnologies, confirmed);

            // Assert

            Assert.Equal(result, "TransferredToLead");
        }
        [Fact]
        public void ResultE_Test()
        {
            // Arrange
            percentageOfTechnologies = 61;
            person.Experience = 3;

            // Act

            var result = home.Result(person, percentageOfTechnologies, confirmed);

            // Assert

            Assert.Equal(result, "TransferredToCTO");
        }
    }
}