using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
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

            while (true)
            {
                SendKeys.Send("{E 20}");
                Thread.Sleep((60 * 5) * 1000);
            }
        }
    }
}

/*using System;
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

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;

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

            Thread.Sleep(3 * 1000);

            bool alternateCursor = true;

            while (true)
            {
            
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
                }*


                this.Cursor = new Cursor(Cursor.Current.Handle);

                if (alternateCursor)
                {
                    Debug.WriteLine("GET SCRAP FROM RESOURCE MACHINE");

                    Thread.Sleep(1000);
                    SendKey("{E}");      
                }
                else
                {
                    Debug.WriteLine("STORE SCRAP");

                    Thread.Sleep(1000);
                    SendKey("{E}");
                    SendKey("{T}");
                    SendKey(" ");
                    SendKey("{TAB}",20);
                }

                Thread.Sleep(1000);


                if (alternateCursor)
                {
                    Move(1440, 0);
                }
                else
                {
                    Move(-1440, 0);
                }

                alternateCursor = !alternateCursor;

                Thread.Sleep(1000);
            }
        }

        private void SendKey(string letter, int amount = 10)
        {
            for (int i = 0; i < amount; i++)
            {
                SendKeys.SendWait(letter);
            }

            SendKeys.Flush();
            Thread.Sleep(1000);
        }

        public static void Move(int xDelta, int yDelta)
        {
            int x = xDelta;//(int)(65536.0 / 1920 * xDelta - 1); //convert to absolute coordinates
            int y = yDelta;//(int)(65536.0 / 1080 * yDelta - 1);

            mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
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
*/