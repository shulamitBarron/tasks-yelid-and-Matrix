using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace threadNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> arr = new List<string>();
        // AutoResetEvent - Notifies a waiting thread that an event has occurred. 
        private AutoResetEvent autoResetEvent = new AutoResetEvent(true); // Must be true so the first thread could not be blocked and could pass the WaitOne command.

        private void fill2()
        {
            autoResetEvent.WaitOne();
          
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(500);
                    arr.Add($"{i} ");
                }
         
          
            autoResetEvent.Set();

        }
        private void fill()
        {
            lock (arr)
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(5000);
                    arr.Add($"{i} ");
                }
            }
            Invoke(new Action(() => arr.ForEach(p => textBox1.Text += p)));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(fill2);         
            th.Start();
            autoResetEvent.WaitOne();
            arr.ForEach(p => textBox1.Text += p);
            autoResetEvent.Set();
        }
    }
}
