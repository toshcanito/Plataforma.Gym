using NUnit.Framework;

namespace Plataforma.Gym.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result = 2;
            var suma = 1 + 1;
            Assert.AreEqual(suma, result);
        }
    }
}