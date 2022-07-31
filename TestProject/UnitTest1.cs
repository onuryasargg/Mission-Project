using Mission_Project.Controllers;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        HomeController home;

        [SetUp]
        public void Setup()
        {
            home = new HomeController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}