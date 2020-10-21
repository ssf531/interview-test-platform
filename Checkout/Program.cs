using System;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             // Arrange
            var till = new Till();
            
            // Act
            till.Scan("AAABBCCCCCCCCCCCCCCCC");
            till.Total();
        }
    }
}
