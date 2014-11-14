using System;

namespace AsynchronousTimer
{
     
    class AsyncTimerTest
    {
        public static void MethodWrite(string str)
        {
            Console.WriteLine(str);
        }
       
        public static void MethodBeep(string str)
        {
            Console.Beep();
        }
       
        static void Main()
        {
            AsyncTimer timer1 = new AsyncTimer(10, 1000, MethodWrite );
            timer1.Start();
            
            AsyncTimer timer2 = new AsyncTimer(20, 2000, MethodBeep);
            timer2.Start();
           
            Console.ReadLine();
        }
    }
}
