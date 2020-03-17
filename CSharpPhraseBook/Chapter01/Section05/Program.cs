// List 1-7
using System;
// using SampleApp;

namespace SampleApp {
    class Program {
        static void Main(string[] args) {
            Product karinto = new Product(123, "かりんとう", 180); 
            int taxIncluded = karinto.GetPriceIncludingTax();
            Console.WriteLine(taxIncluded);
        }
    }
}
