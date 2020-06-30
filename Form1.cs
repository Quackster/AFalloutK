using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AFKer
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("Fallout76")[0];
            p.WaitForInputIdle();
            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);


            var random = new Random();
            
            var list = new List<string> { "A", "S", "D", "W" };

            while (true)
            {
                int seconds = random.Next(1, 10);
                int index = random.Next(list.Count);

                /*switch (list[index])
                {
                    case "A":
                        Keyboard.HoldKey((byte)Keys.A, seconds * 1000);
                        break;
                    case "S":
                        Keyboard.HoldKey((byte)Keys.S, seconds * 1000);
                        break;
                    case "D":
                        Keyboard.HoldKey((byte)Keys.D, seconds * 1000);
                        break;
                    case "W":
                        Keyboard.HoldKey((byte)Keys.W, seconds * 1000);
                        break;
                }*/

                for (int i = 0; i < 1000; i++)
                {
                    SendKeys.Send(list[index]);
                    Thread.Sleep(100);
                }

                Thread.Sleep(seconds * 1000);
            }
        }
    }

    public class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int PauseBetweenStrokes = 50;

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag

        public static void HoldKey(byte key, int duration)
        {
            int totalDuration = 0;
            while (totalDuration < duration)
            {
                keybd_event(key, 0, KEY_DOWN_EVENT, 0);
                keybd_event(key, 0, KEY_UP_EVENT, 0);
                System.Threading.Thread.Sleep(PauseBetweenStrokes);
                totalDuration += PauseBetweenStrokes;
            }
        }
    }
}
