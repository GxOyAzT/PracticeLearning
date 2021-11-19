using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.OpenClosePrinciple
{
    public class OpenClose
    {
        public static void Execute()
        {

        }
    }

    public interface IProductRepo 
    {
        List<Product> GetProducts();
    }

    public class ProductRepo : IProductRepo
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
                    Color = Color.Blue,
                    Size = Size.Big
                },
                new Product()
                {
                    Id = 4,
                    Name = "Name 4",
                    Price = 100,
                    Color = Color.Green,
                    Size = Size.Big
                },
                new Product()
                {
                    Id = 5,
                    Name = "Name 5",
                    Price = 40,
                    Color = Color.Green,
                    Size = Size.Small
                },
            };
        }
    }

    public interface IFilter<TEntity>
    {
        bool IsSatisfied(TEntity product);
    }

    public class FilterProductByColor : IFilter<Product>
    {
        private readonly Color _color;

        public FilterProductByColor(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product product)
        {
            if (_color == product.Color)
                return true;

            return false;
        }
    }

    public class FilterProductByMaxPrice : IFilter<Product>
    {
        private readonly decimal price;

        public FilterProductByMaxPrice(decimal price)
        {
            this.price = price;
        }

        public bool IsSatisfied(Product product)
        {
            if (product.Price <= price)
                return true;

            return false;
        }
    }

    public class FilterProductBySize : IFilter<Product>
    {
        private readonly Size _size;

        public FilterProductBySize(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product product)
        {
            if (_size == product.Size)
                return true;

            return false;
        }
    }

    public class GetProductsAndFiltr
    {
        private readonly IProductRepo _productRepo;
        private readonly List<IFilter<Product>> _filters;

        public GetProductsAndFiltr(
            IProductRepo productRepo,
            List<IFilter<Product>> filters)
        {
            _productRepo = productRepo;
            _filters = filters;
        }

        public List<Product> Filter()
        {
            var output = new List<Product>();

            foreach(var product in _productRepo.GetProducts())
            {
                var shouldBeInOutput = true;

                foreach (var filter in _filters)
                    if (!filter.IsSatisfied(product))
                        shouldBeInOutput = false;

                if (shouldBeInOutput)
                    output.Add(product);
            }

            return output;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }

    public enum Color
    {
        Green,
        Red,
        Blue
    }

    public enum Size
    {
        Big,
        Medium,
        Small
    }
}
