using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(235, "大福もち", 160);
            int karintoTax = karinto.GetTax();
            int daifukuTax = daifuku.GetTax();

            Console.WriteLine("{0} {1} {2}", karinto.Name, karinto.Price, karintoTax);
            Console.WriteLine("{0} {1} {2}", daifuku.Name, daifuku.Price, daifukuTax);

        }
    }
}
