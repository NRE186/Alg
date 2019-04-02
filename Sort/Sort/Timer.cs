using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sort
{
    class Timer
    {
        private TimerCallback callback;
        private object p;
        private int v1;
        private int v2;

        public Timer(TimerCallback callback, object p, int v1, int v2)
        {
            this.callback = callback;
            this.p = p;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
