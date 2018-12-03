using System;

using System.Runtime.InteropServices;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace deligates
{
    class Program
    {
        //delegate void printIndexHandler(int index);




        //public class Mouse
        //{
        //    [DllImport("user32.dll", CharSet = CharSet.Auto,
        //     CallingConvention = CallingConvention.StdCall)]
        //    public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //    static int hHook = 0;
        //    public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //    HookProc MouseHookProcedure;

        //    private void ActivateMouseHook_Click(object sender, System.EventArgs e)
        //    {
        //        if (hHook == 0)
        //        {
        //            MouseHookProcedure = new HookProc( MouseHookProc);
        //            hHook = SetWindowsHookEx(WH_MOUSE, MouseHookProcedure, (IntPtr)0, AppDomain.GetCurrentThreadId());
        //        }
        //    }
        //    [DllImport("user32.dll", CharSet= CharSet.Auto,CallingConvention= CallingConvention.StdCall)]
        //      public static extern bool UnhookWindowsHookEx(int idHook);

        //    private void DeactivateMouseHook_Click(object sender, System.EventArgs e)
        //    {
        //        bool ret = UnhookWindowsHookEx(hHook);
        //    }

        //    [StructLayout(LayoutKind.Sequential)]
        //    public class POINT
        //    {
        //        public int x;
        //        public int y;
        //    }

        //    [StructLayout(LayoutKind.Sequential)]
        //    public class MouseHookStruct
        //    {
        //        public POINT pt;
        //        public int hwnd;
        //        public int wHitTestCode;
        //        public int dwExtraInfo;
        //    }

        //    public static int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        //    {
        //        MouseHookStruct MyMouseHookStruct = (MouseHookStruct)
        //            Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));

        //        // You can get the coördinates using the MyMouseHookStruct.
        //        // ...       
        //        return CallNextHookEx(hHook, nCode, wParam, lParam);
        //    }
        //    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int CallNextHookEx(int idHook, int nCode,IntPtr wParam, IntPtr lParam);


        //    private void mh_MouseDownEvent(object sender, MouseEventArgs e)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            richTextBox1.AppendText("Left Button Press\n");
        //        }
        //        if (e.Button == MouseButtons.Right)
        //        {
        //            richTextBox1.AppendText("Right Button Press\n");
        //        }
        //    }

        //    private void mh_MouseUpEvent(object sender, MouseEventArgs e)
        //    {

        //        if (e.Button == MouseButtons.Left)
        //        {
        //            richTextBox1.AppendText("Left Button Release\n");
        //        }
        //        if (e.Button == MouseButtons.Right)
        //        {
        //            richTextBox1.AppendText("Right Button Release\n");
        //        }

        //    }
        //    private void mh_MouseClickEvent(object sender, MouseEventArgs e)
        //    {
        //        //MessageBox.Show(e.X + "-" + e.Y);
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            string sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
        //            label1.Text = sText;
        //        }
        //    }





        //}
        static void Main(string[] args)
        {


            Console.WriteLine("eszR");

            Environment.Exit(-1);
            //printIndexHandler[] array =new printIndexHandler[10];
            //TimeSpan interval = new TimeSpan(0,1,0);

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Sleep for 2 seconds.");

            //}
            //for (int i = 0; i < array.Length; i++)
            //{          
            //    array[i] = (s)=>
            //    {
            //        Thread.Sleep(interval);
            //        Console.WriteLine(s);
            //       // Thread.Sleep(1000);


            //    };
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    array[i](i);
            //}
            Console.WriteLine("eszR");
        }
    }
}

