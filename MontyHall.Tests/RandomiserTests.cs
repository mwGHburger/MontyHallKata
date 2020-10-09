using System.Reflection;
using Xunit;

namespace MontyHall.Tests
{
    public class RandomiserTests
    {
        [Fact]
        public void ShouldGenerateANumberWithinGivenRange()
        {
            var random = new Randomiser();
            var minValue = 0;
            var maxValue = 3;

            var actual = random.GenerateNumber(maxValue);

            Assert.InRange(actual,minValue,maxValue);
        }
    }
}