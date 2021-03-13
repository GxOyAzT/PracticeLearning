using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.Models
{
    public class ProductDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quanitiy { get; set; }
    }
}
