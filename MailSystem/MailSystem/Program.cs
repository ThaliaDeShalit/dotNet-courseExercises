using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            mm.MailArrived += HandleMailArrived;

            mm.SimulateMailArrived();

            // this part is the timer part, calls simulate mail arrived every second for 10 seconds, 
            // which results in a total of 10 calls before the thread ends
            Timer timer = new Timer(new TimerCallback(TimerProc));
            timer.Change(1000, 1000);

            Thread.Sleep(10000);
        }

        private static void TimerProc(object state)
        {
            MailManager m = new MailManager();
            m.MailArrived += HandleMailArrived;

            m.SimulateMailArrived();
        }

        internal static void HandleMailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine(
@"message title is: 
{0}
message body is:
{1}
", e.Title, e.Body);
        }
    }
}
