using Moq;
using TestsPractice.Application;
using Xunit;

namespace TestsPractice.Tests
{
    public class ServiceATests
    {
        [Fact]
        public void TestA()
        {
            Mock<IServiceA> serviceA = new Mock<IServiceA>();

            var value = "ABC";

            serviceA.Setup(s => s.ReturnValue(It.IsAny<string>())).Returns(value);

            var serviceB = new ServiceB(serviceA.Object);

            serviceB.returnValue(true, value);

            serviceA.Verify(mock => mock.ReturnValue(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void TestC()
        {
            Mock<IServiceA> serviceA = new Mock<IServiceA>();

            var value = "ABC";

            serviceA.Setup(s => s.ReturnValue(It.IsAny<string>())).Returns(value);

            var serviceB = new ServiceB(serviceA.Object);

            serviceB.returnValue(true, value);

            serviceA.Verify(mock => mock.ReturnValue(It.Is<string>(actual => actual == value)), Times.Once());
        }

        [Fact]
        public void TestB()
        {
            Mock<IServiceA> serviceA = new Mock<IServiceA>();

            var value = "ABC";

            serviceA.Setup(s => s.ReturnValue(It.IsAny<string>())).Returns("ABCDEF");

            var serviceB = new ServiceB(serviceA.Object);

            serviceB.returnValue(false, value);

            serviceA.Verify(mock => mock.ReturnValue(It.IsAny<string>()), Times.Never());
        }
    }
}
