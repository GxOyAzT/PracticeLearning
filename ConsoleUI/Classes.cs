using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public abstract class Bread
    {
        public void Create()
        {
            AddIngredients();
            MixIngredients();
            Bake();
            Slice();
        }

        protected abstract void AddIngredients();
        protected virtual void MixIngredients()
        {
            Console.WriteLine($"Mix Ingredients. { this.GetType().Name }");
        }
        protected abstract void Bake();
        protected abstract void Slice();
    }

    public class Baguette : Bread
    {
        protected override void AddIngredients()
        {
            Console.WriteLine("Baguette add ingredients.");
        }

        protected override void Bake()
        {
            Console.WriteLine("Baguette bake.");

        }

        protected override void Slice()
        {
            Console.WriteLine("Baguette slice.");
        }
    }

    public class Roll : Bread
    {
        protected override void AddIngredients()
        {
            Console.WriteLine("Roll add ingredients.");
        }

        protected override void Bake()
        {
            Console.WriteLine("Roll bake.");

        }

        protected override void Slice()
        {
            Console.WriteLine("Roll slice.");
        }
    }
}