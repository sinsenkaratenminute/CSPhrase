using System;

namespace Section02 {

    // List 7-14
    class MonthDay {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public MonthDay(int month, int day) {
            this.Month = month;
            this.Day = day;
        }

        // MonthDayどうしの比較をする
        public override bool Equals(object obj) {
            var other = obj as MonthDay;
            if (other == null)
                throw new ArgumentException();
            return this.Day == other.Day && this.Month == other.Month;
        }

        // ハッシュコードを求める
        public override int GetHashCode() {
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }

    }
}