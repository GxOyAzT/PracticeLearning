using ConsolePractice.OpenClosePrinciple;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.ConsoleTests
{
    public class OpenCloseTests
    {
        [Fact]
        public void TestA()
        {
            var _processor = new GetProductsAndFiltr(new ProuctRepoMockOne(), new List<IFilter<Product>>() { new FilterProductByColor(Color.Blue) });

            var output = _processor.Filter();

            Assert.Equal(2, output.Count);
            Assert.NotNull(output.FirstOrDefault(e => e.Id == 1));
            Assert.NotNull(output.FirstOrDefault(e => e.Id == 2));
        }

        [Fact]
        public void TestB()
        {
            var _processor = new GetProductsAndFiltr(
                new ProuctRepoMockTwo(), 
                new List<IFilter<Product>>() 
                { 
                    new FilterProductByColor(Color.Blue),
                    new FilterProductBySize(Size.Big)
                });

            var output = _processor.Filter();

            Assert.Equal(2, output.Count);
            Assert.NotNull(output.FirstOrDefault(e => e.Id == 1));
            Assert.NotNull(output.FirstOrDefault(e => e.Id == 4));
        }
    }

    public class ProuctRepoMockOne : IProductRepo
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Name 1",
                    Price = 50,
                    Color = Color.Blue,
                    Size = Size.Big
                },
                new Product()
                {
                    Id = 2,
                    Name = "Name 2",
                    Price = 20,
                    Color = Color.Blue,
                    Size = Size.Medium
                },
                new Product()
                {
                    Id = 3,
                    Name = "Name 3",
                    Price = 50,
                    Color = Color.Green,
                    Size = Size.Big
                }
            };
        }
    }

    public class ProuctRepoMockTwo : IProductRepo
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Name 1",
                    Price = 50,
                    Color = Color.Blue,
                    Size = Size.Big
                },
                new Product()
                {
                    Id = 2,
                    Name = "Name 2",
                    Price = 20,
                    Color = Color.Blue,
                    Size = Size.Medium
                },
                new Product()
                {
                    Id = 3,
                    Name = "Name 3",
                    Price = 50,
                    Color = Color.Green,
                    Size = Size.Big
                },
                new Product()
                {
                    Id = 4,
                    Name = "Name 4",
                    Price = 50,
                    Color = Color.Blue,
                    Size = Size.Big
                }
            };
        }
    }
}
