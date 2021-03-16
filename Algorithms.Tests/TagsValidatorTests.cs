using Algorithms.ClassLibrary;
using Xunit;

namespace Algorithms.Tests
{
    public class TagsValidatorTests
    {
        [Theory]
        [InlineData("qjfqppfq,eoqofiqie,iqjfp", true)]
        [InlineData("qjfqppfq,eoqofiqie,iqjfp,", false)]
        [InlineData(",qjfqppfq,eoqofiqie,iqjfp", false)]
        [InlineData("qjfqppfq,eoqofiqie,,iqjfp", false)]
        [InlineData("qjfqppfq,,,,eoqofiqie,iqjfp", false)]
        [InlineData("qjfqppfq,eoq ofiqie,iqjfp", false)]
        [InlineData(" ", false)]
        [InlineData("", true)]
        public void Tests(string input, bool expexted)
        {
            Assert.Equal(expexted, new TagsValidator().validate(input));
        }
    }
}
