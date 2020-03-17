// List 2-2

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            // フィートからメートルへの対応表を出力
            for (int feet = 1; feet <= 10; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0} f = {1:0.0000} m", feet, meter);
            }
        }

        // フィートからメートルを求める
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }
    }
}
