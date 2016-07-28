using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private static CancellationTokenSource cts = new CancellationTokenSource();
        private static CancellationToken ct = cts.Token;

        private static EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
        private static EventWaitHandle threadExitewh = new EventWaitHandle(false, EventResetMode.AutoReset);

        public Form1()
        {
            InitializeComponent();
            ct.Register(CancelMethod);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(CalculatePrimes);

            t.Start(cts);


        }

        private void CalculatePrimes(object cts)
        {
            ArrayList primeNumbers = new ArrayList();
            int from, to;

            if (int.TryParse(textBoxFromRange.Text, out from) && int.TryParse(textBoxToRange.Text, out to))
            {
                for (int i = from; i <= to; i++)
                {
                    if (ewh.WaitOne(0))
                    {
                        //threadExitewh.Set();
                        ((CancellationTokenSource)cts).Cancel();
                        Thread.CurrentThread.Abort();
                    }
                    else
                    {
                        if (isPrime(i))
                        {
                            primeNumbers.Add(i);
                        }
                    }
                }

                listBoxResults.Invoke(new Action(() => listBoxResults.Items.Clear()));
                foreach (int prime in primeNumbers)
                {
                    listBoxResults.Invoke(new Action(() => listBoxResults.Items.Add(prime)));
                }
            }
            else
            {
                MessageBox.Show("Please enter two natural numbers");
            }
        }


        private bool isPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; (double)i <= Math.Sqrt((double)num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            ewh.Set();
            try
            {
                while (true)
                {
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch
            {

            }

            //Thread t = new Thread(TerminateCalculatingThread);
            //t.Start();
        }
        //private void TerminateCalculatingThread()
        //{
        //    //Program.Cts.Cancel();

        //    WaitHandle.SignalAndWait(ewh, threadExitewh);
        //}

        private void CancelMethod()
        {
            MessageBox.Show("Calculation canceled");
        }
    }
}
