using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 8")]
    class SampleCode  {
        [ListNo("List 8-1")]
        public void CreateDateTime() {
            var dt1 = new DateTime(2016, 2, 15);
            var dt2 = new DateTime(2016, 2, 15, 8, 45, 20);
            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
        }

        [ListNo("List 8-2")]
        public void TodayAndNow() {
            var today = DateTime.Today;
            var now = DateTime.Now;
            Console.WriteLine("Today : {0}", today);
            Console.WriteLine("Now : {0}", now);
        }

        [ListNo("List 8-3")]
        public void GetPropertyValue() {
            var now = DateTime.Now;
            int year = now.Year;                 // 年: Year
            int month = now.Month;               // 月: Month
            int day = now.Day;                   // 日: Day
            int hour = now.Hour;                 // 時: Hour
            int minute = now.Minute;             // 分: Minute
            int second = now.Second;             // 秒: Second
            int millisecond = now.Millisecond;   // 1/100秒: Millisecond

            Console.WriteLine($"{now}");
            Console.WriteLine($"{year}/{month}/{day} {hour}:{minute}:{second} {millisecond}");
        }

        [ListNo("List 8-4")]
        public void TestDayOfWeek() {
            var today = DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
                Console.WriteLine("今日は日曜日です");
            else
                Console.WriteLine("今日は日曜日ではありません");
        }

        [ListNo("List 8-6")]
        public void IsLeapYear() {
            var isLeapYear = DateTime.IsLeapYear(2016);
            if (isLeapYear)
                Console.WriteLine("閏年です");
            else
                Console.WriteLine("閏年ではありません");
        }


        [ListNo("List 8-7")]
        public void StringToDateTime() {
            DateTime dt1;
            if (DateTime.TryParse("2017/6/21", out dt1))
                Console.WriteLine(dt1);
            DateTime dt2;
            if (DateTime.TryParse("2017/6/21 10:41:38", out dt2))
                Console.WriteLine(dt2);
        }

        [ListNo("List 8-8")]
        public void StringToDateTime3() {
            DateTime dt;
            if (DateTime.TryParse("平成28年3月15日", out dt))
                Console.WriteLine(dt);
        }

    }
}
