using Algorithms.ClassLibrary;
using Xunit;

namespace Algorithms.Tests
{
    public class WatchlistNormalizeNameTests
    {
        [Theory]
        [InlineData("ABC", "abc")]
        [InlineData("ABCł", "abcl")]
        [InlineData("Beyoncé", "beyonce")]
        [InlineData("Be yonce", "beyonce")]
        [InlineData("beyoncé", "beyonce")]
        [InlineData("Be “Y” Once", "beyonce")]
        [InlineData("Be “Y|” Once", "beyonce")]
        [InlineData("Be “Y”,./@#$%^&*()-_=+! Once", "beyonce")]
        [InlineData("áéíóúçce", "aeioucce")]
        public void TestA(string input, string expeted)
        {
            WatchlistNormalizeName _processor = new WatchlistNormalizeName();

            var output = _processor.Normalize(input);

            Assert.Equal(expeted, output);
        }
    }
}
