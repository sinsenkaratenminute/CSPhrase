using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }
    [SampleCode("Chapter 14")]
    class SampleCode {
        [ListNo("List 14-25")]
        public void LocalTimeAndUniversalTime() {
            // 現地時刻を得る
            var now = DateTimeOffset.Now;
            Console.WriteLine("Now = {0}", now);
            // UTC(協定世界時)に変換する
            var utc = now.ToUniversalTime();
            Console.WriteLine("UTC = {0}", utc);
            // UTC(協定世界時)から現地時刻に変換する
            var localTime = utc.ToLocalTime();
            Console.WriteLine("LocalTime = {0}", localTime);
        }


        [ListNo("List 14-26")]
        public void LocalTimeAndUniversalTime2() {
            // 現地時刻を得る
            var now = DateTimeOffset.Now;
            // UTC(協定世界時)に変換する
            var utc = now.ToUniversalTime();
            // 現在の時刻と、そこから変換したUTCを比較する
            if (now == utc)
                Console.WriteLine("'{0}' == '{1}'", now, utc);
            else
                Console.WriteLine("'{0}' != '{1}'", now, utc);
        }


        [ListNo("List 14-27")]
        public void StringToDateTimeOffset() {
            DateTimeOffset time;
            if (DateTimeOffset.TryParse("2016/03/26 1:07:21 +09:00", out time)) {
                Console.WriteLine("{0} | {1}", time, time.ToUniversalTime());
            }
        }

        [ListNo("List 14-28")]
        public void FindSystemTimeZoneById() {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            Console.WriteLine("Utc との差      {0}", tz.BaseUtcOffset);
            Console.WriteLine("タイムゾーンID  {0}", tz.Id);
            Console.WriteLine("表示名          {0}", tz.DisplayName);
            Console.WriteLine("標準時の表示名  {0}", tz.StandardName);
            Console.WriteLine("夏時間の表示名  {0}", tz.DaylightName);
            Console.WriteLine("夏時間の有無    {0}", tz.SupportsDaylightSavingTime);
        }

        [ListNo("List 14-29")]
        public void GetSystemTimeZones() {
            // タイムゾーンのId一覧を得る。
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timeZones)
                Console.WriteLine("'{0}' - '{1}'", timezone.Id, timezone.DisplayName);
        }


        [ListNo("List 14-30")]
        public void ConvertTime() {
            DateTimeOffset utc = DateTimeOffset.UtcNow;
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            // 例えば、上記のようなコードでTimeZoneInfoが取得されている
            //……
            DateTimeOffset time = TimeZoneInfo.ConvertTime(utc, timezone);
            Console.WriteLine("India Standard Time {0} {1}", time, time.Offset);
        }

        [ListNo("List 14-31")]
        public void ConvertTime2() {
            DateTimeOffset utc = DateTimeOffset.UtcNow;
            var ist = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utc, "India Standard Time");
            Console.WriteLine("India Standard Time {0} {1}", ist, ist.Offset);
        }

        [ListNo("List 14-32")]
        public void ConvertTimeBySystemTimeZoneId() {
            // ローカル時刻（日本の時刻）を得る
            var local = new DateTime(2016, 8, 11, 11, 20, 0);
            // DateTimeOffsetに変換する
            var date = new DateTimeOffset(local);
            // "Pacific Standard Time"の時刻に変換する
            DateTimeOffset pst = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, "Pacific Standard Time");
            Console.WriteLine(pst);
        }

        [ListNo("List 14-33")]
        public void ConvertTimeBySystemTimeZoneId2() {
            var chinatz = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            var chinaTime = new DateTimeOffset(2016, 4, 6, 9, 0, 0, chinatz.BaseUtcOffset);
            // 変数chinaTimeに北京の時刻(DateTimeOffset)が入っている
            // この時刻を"Hawaiian Standard Time"の時刻に変換する
            var hawaiiTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(chinaTime, "Hawaiian Standard Time");
            Console.WriteLine(chinaTime);
            Console.WriteLine(hawaiiTime);
        }

    }
}
