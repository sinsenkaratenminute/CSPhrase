// List 2-1

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            // フィートからメートルへの対応表を出力
            for (int feet = 1; feet <= 10; feet++) {
                double meter = feet * 0.3048;
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }
    }
}
