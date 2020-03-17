using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    // List 17-2
    class GreetingMorning : GreetingBase {
        public override string GetMessage() {
            return "おはよう";
        }
    }

    class GreetingAfternoon : GreetingBase {
        public override string GetMessage() {
            return "こんにちは";
        }
    }

    class GreetingEvening : GreetingBase {
        public override string GetMessage() {
            return "こんばんは";
        }
    }
}
