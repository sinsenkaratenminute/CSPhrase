using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section0102 {
    // List 17-6
    class GreetingMorning : IGreeting {
        public string GetMessage() {
            return "おはよう";
        }
    }

    class GreetingAfternoon : IGreeting {
        public string GetMessage() {
            return "こんにちは";
        }
    }

    class GreetingEvening : IGreeting {
        public string GetMessage() {
            return "こんばんは";
        }
    }
}
