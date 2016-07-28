using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace PrimesCalculator
{
    public static class Program
    {
        //private static CancellationTokenSource cts = new CancellationTokenSource();
        //private static CancellationToken token = cts.Token; 


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //public static CancellationToken Token
        //{
        //    get
        //    {
        //        return token;
        //    }
        //}

        //public static CancellationTokenSource Cts
        //{
        //    get
        //    {
        //        return cts;
        //    }
        //}
    }
}
