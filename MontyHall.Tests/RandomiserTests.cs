using System.Reflection;
using Xunit;

namespace MontyHall.Tests
{
    public class RandomiserTests
    {
        [Theory]
        [InlineData(0,3)]
        public void ShouldGenerateANumberWithinGivenRange(int minValue, int maxValue)
        {
            var random = new Randomiser();

            var actual = random.GenerateNumber(maxValue);

            Assert.InRange(actual,minValue,maxValue);
        }
    }
}