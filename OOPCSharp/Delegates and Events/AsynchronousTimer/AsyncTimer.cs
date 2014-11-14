using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace AsynchronousTimer
{
    public class AsyncTimer
    {
        private int ticks;
        private int interval;
        private Action<string> actionMetod;

        public AsyncTimer(int ticks, int interval, Action<string> actionMetod)
        {
            this.ticks = ticks;
            this.interval = interval;
            this.actionMetod = actionMetod;
        }

        public void Start()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
            aTimer.Interval = this.interval;
            aTimer.Start();
        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            Timer aTimer = (Timer)source;
            this.actionMetod(this.ticks + "");
            this.ticks--;
            if (this.ticks == 0)
            {
                aTimer.Stop();
                Console.WriteLine("Destroying timer");
            }
        }
    }
}
