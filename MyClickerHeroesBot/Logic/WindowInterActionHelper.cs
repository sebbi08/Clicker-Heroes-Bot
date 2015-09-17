using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MyClickerHeroesBot.Logic
{
    class WindowInterActionHelper
    {

        private readonly IntPtr _handler =  WinGetHandle();

        private static WindowInterActionHelper _helperInstance;


        public static int Srccopy = 13369376;



        public static WindowInterActionHelper getInstance()
        {
            return _helperInstance ?? (_helperInstance = new WindowInterActionHelper());
        }


        public void SendLeftClick(Point p)
        {

            SendMessage(_handler, (int)WMessages.WM_LBUTTONDOWN, 0, MakeLParam(p));
            SendMessage(_handler, (int)WMessages.WM_LBUTTONUP, 0, MakeLParam(p));
        }
        
        public void SendLeftClick(Point p,int count)
        {
            for (int i = 0; i < count; i++)
            {
                SendLeftClick(p);
            }
        }


        public void SendKeyPres(VKeys key)
        {
            SendKeyDown(key);
            SendKeyUp(key);
        }

        public void SendKeyDown(VKeys key)
        {

            SendMessage(_handler, (int)WMessages.WM_KEYDOWN, (int)key, 0);
        }

        public void SendKeyUp(VKeys key)
        {

            SendMessage(_handler, (int)WMessages.WM_KEYUP, (int)key, 0);
        }

        public static IntPtr WinGetHandle()
        {

            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains("Clicker Heroes"))
                {
                    return pList.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        public Bitmap CaptureWindow()
        {

            IntPtr hdcSrc = User32.GetWindowDC(_handler);

            RECT windowRect = new RECT();
            User32.GetWindowRect(_handler, ref windowRect);

            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
            Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, Srccopy);
            Gdi32.SelectObject(hdcDest, hOld);
            Gdi32.DeleteDC(hdcDest);
            User32.ReleaseDC(_handler, hdcSrc);

            Image image = Image.FromHbitmap(hBitmap);
            Gdi32.DeleteObject(hBitmap);


            return new Bitmap(image);
        }

        private Rectangle searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        {
            BitmapData smallData =
              smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapData bigData =
              bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                       System.Drawing.Imaging.ImageLockMode.ReadOnly,
                       System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int smallStride = smallData.Stride;
            int bigStride = bigData.Stride;

            int bigWidth = bigBmp.Width;
            int bigHeight = bigBmp.Height - smallBmp.Height + 1;
            int smallWidth = smallBmp.Width * 3;
            int smallHeight = smallBmp.Height;

            Rectangle location = Rectangle.Empty;
            int margin = Convert.ToInt32(255.0 * tolerance);

            unsafe
            {
                byte* pSmall = (byte*)(void*)smallData.Scan0;
                byte* pBig = (byte*)(void*)bigData.Scan0;

                int smallOffset = smallStride - smallBmp.Width * 3;
                int bigOffset = bigStride - bigBmp.Width * 3;

                bool matchFound = true;

                for (int y = 0; y < bigHeight; y++)
                {
                    for (int x = 0; x < bigWidth; x++)
                    {
                        byte* pBigBackup = pBig;
                        byte* pSmallBackup = pSmall;

                        //Look for the small picture.
                        for (int i = 0; i < smallHeight; i++)
                        {
                            int j = 0;
                            matchFound = true;
                            for (j = 0; j < smallWidth; j++)
                            {
                                //With tolerance: pSmall value should be between margins.
                                int inf = pBig[0] - margin;
                                int sup = pBig[0] + margin;
                                if (sup < pSmall[0] || inf > pSmall[0])
                                {
                                    matchFound = false;
                                    break;
                                }

                                pBig++;
                                pSmall++;
                            }

                            if (!matchFound) break;

                            //We restore the pointers.
                            pSmall = pSmallBackup;
                            pBig = pBigBackup;

                            //Next rows of the small and big pictures.
                            pSmall += smallStride * (1 + i);
                            pBig += bigStride * (1 + i);
                        }

                        //If match found, we return.
                        if (matchFound)
                        {
                            location.X = x;
                            location.Y = y;
                            location.Width = smallBmp.Width;
                            location.Height = smallBmp.Height;
                            break;
                        }
                        //If no match found, we restore the pointers and continue.
                        else
                        {
                            pBig = pBigBackup;
                            pSmall = pSmallBackup;
                            pBig += 3;
                        }
                    }

                    if (matchFound) break;

                    pBig += bigOffset;
                }
            }

            bigBmp.UnlockBits(bigData);
            smallBmp.UnlockBits(smallData);

            return location;
        }

        public Rectangle SearchBitmapAutoTolerance(Bitmap smallBmp, Bitmap screenShot)
        {
            double i = 0;
            while (i <= 0.1)
            {
                Rectangle find = searchBitmap(smallBmp, screenShot, i);
                if (!find.IsEmpty)
                {
                    Rectangle result = new Rectangle(find.X-8,find.Y-31,find.Width,find.Height);
                    return result;
                }
                i = i + 0.01;
            }
            return Rectangle.Empty;
        }
    

        #region heplerMethods

        /// <summary>
        /// MakeLParam Macro
        /// </summary>
        private int MakeLParam(Point point)
        {
            return ((point.Y << 16) | (point.X & 0xffff));
        }

        ///summary>
        /// Virtual Messages
        /// </summary>
        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202,  //Left mousebutton up
            WM_LBUTTONDBLCLK = 0x203, //Left mousebutton doubleclick
            WM_RBUTTONDOWN = 0x204, //Right mousebutton down
            WM_RBUTTONUP = 0x205,   //Right mousebutton up
            WM_RBUTTONDBLCLK = 0x206, //Right mousebutton doubleclick
            WM_KEYDOWN = 0x100,  //Key down
            WM_KEYUP = 0x101,   //Key up
        }

        /// <summary>
        /// Virtual Keys
        /// </summary>
        public enum VKeys : int
        {
            VK_LBUTTON = 0x01,   //Left mouse button 
            VK_RBUTTON = 0x02,   //Right mouse button 
            VK_CANCEL = 0x03,   //Control-break processing 
            VK_MBUTTON = 0x04,   //Middle mouse button (three-button mouse) 
            VK_BACK = 0x08,   //BACKSPACE key 
            VK_TAB = 0x09,   //TAB key 
            VK_CLEAR = 0x0C,   //CLEAR key 
            VK_RETURN = 0x0D,   //ENTER key 
            VK_SHIFT = 0x10,   //SHIFT key 
            VK_CONTROL = 0x11,   //CTRL key 
            VK_MENU = 0x12,   //ALT key 
            VK_PAUSE = 0x13,   //PAUSE key 
            VK_CAPITAL = 0x14,   //CAPS LOCK key 
            VK_ESCAPE = 0x1B,   //ESC key 
            VK_SPACE = 0x20,   //SPACEBAR 
            VK_PRIOR = 0x21,   //PAGE UP key 
            VK_NEXT = 0x22,   //PAGE DOWN key 
            VK_END = 0x23,   //END key 
            VK_HOME = 0x24,   //HOME key 
            VK_LEFT = 0x25,   //LEFT ARROW key 
            VK_UP = 0x26,   //UP ARROW key 
            VK_RIGHT = 0x27,   //RIGHT ARROW key 
            VK_DOWN = 0x28,   //DOWN ARROW key 
            VK_SELECT = 0x29,   //SELECT key 
            VK_PRINT = 0x2A,   //PRINT key
            VK_EXECUTE = 0x2B,   //EXECUTE key 
            VK_SNAPSHOT = 0x2C,   //PRINT SCREEN key 
            VK_INSERT = 0x2D,   //INS key 
            VK_DELETE = 0x2E,   //DEL key 
            VK_HELP = 0x2F,   //HELP key
            VK_0 = 0x30,   //0 key 
            VK_1 = 0x31,   //1 key 
            VK_2 = 0x32,   //2 key 
            VK_3 = 0x33,   //3 key 
            VK_4 = 0x34,   //4 key 
            VK_5 = 0x35,   //5 key 
            VK_6 = 0x36,    //6 key 
            VK_7 = 0x37,    //7 key 
            VK_8 = 0x38,   //8 key 
            VK_9 = 0x39,    //9 key 
            VK_A = 0x41,   //A key 
            VK_B = 0x42,   //B key 
            VK_C = 0x43,   //C key 
            VK_D = 0x44,   //D key 
            VK_E = 0x45,   //E key 
            VK_F = 0x46,   //F key 
            VK_G = 0x47,   //G key 
            VK_H = 0x48,   //H key 
            VK_I = 0x49,    //I key 
            VK_J = 0x4A,   //J key 
            VK_K = 0x4B,   //K key 
            VK_L = 0x4C,   //L key 
            VK_M = 0x4D,   //M key 
            VK_N = 0x4E,    //N key 
            VK_O = 0x4F,   //O key 
            VK_P = 0x50,    //P key 
            VK_Q = 0x51,   //Q key 
            VK_R = 0x52,   //R key 
            VK_S = 0x53,   //S key 
            VK_T = 0x54,   //T key 
            VK_U = 0x55,   //U key 
            VK_V = 0x56,   //V key 
            VK_W = 0x57,   //W key 
            VK_X = 0x58,   //X key 
            VK_Y = 0x59,   //Y key 
            VK_Z = 0x5A,    //Z key
            VK_NUMPAD0 = 0x60,   //Numeric keypad 0 key 
            VK_NUMPAD1 = 0x61,   //Numeric keypad 1 key 
            VK_NUMPAD2 = 0x62,   //Numeric keypad 2 key 
            VK_NUMPAD3 = 0x63,   //Numeric keypad 3 key 
            VK_NUMPAD4 = 0x64,   //Numeric keypad 4 key 
            VK_NUMPAD5 = 0x65,   //Numeric keypad 5 key 
            VK_NUMPAD6 = 0x66,   //Numeric keypad 6 key 
            VK_NUMPAD7 = 0x67,   //Numeric keypad 7 key 
            VK_NUMPAD8 = 0x68,   //Numeric keypad 8 key 
            VK_NUMPAD9 = 0x69,   //Numeric keypad 9 key 
            VK_SEPARATOR = 0x6C,   //Separator key 
            VK_SUBTRACT = 0x6D,   //Subtract key 
            VK_DECIMAL = 0x6E,   //Decimal key 
            VK_DIVIDE = 0x6F,   //Divide key
            VK_F1 = 0x70,   //F1 key 
            VK_F2 = 0x71,   //F2 key 
            VK_F3 = 0x72,   //F3 key 
            VK_F4 = 0x73,   //F4 key 
            VK_F5 = 0x74,   //F5 key 
            VK_F6 = 0x75,   //F6 key 
            VK_F7 = 0x76,   //F7 key 
            VK_F8 = 0x77,   //F8 key 
            VK_F9 = 0x78,   //F9 key 
            VK_F10 = 0x79,   //F10 key 
            VK_F11 = 0x7A,   //F11 key 
            VK_F12 = 0x7B,   //F12 key
            VK_SCROLL = 0x91,   //SCROLL LOCK key 
            VK_LSHIFT = 0xA0,   //Left SHIFT key
            VK_RSHIFT = 0xA1,   //Right SHIFT key
            VK_LCONTROL = 0xA2,   //Left CONTROL key
            VK_RCONTROL = 0xA3,    //Right CONTROL key
            VK_LMENU = 0xA4,      //Left MENU key
            VK_RMENU = 0xA5,   //Right MENU key
            VK_PLAY = 0xFA,   //Play key
            VK_ZOOM = 0xFB, //Zoom key 
        }

        #endregion

        #region dll Imports
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private static class User32
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        }

        private class Gdi32
        {
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        #endregion

        public void ClearMousFokus()
        {
            SendLeftClick(new Point(1, 1)); 
        }


        public bool FoundProcess()
        {
            return !_handler.Equals(IntPtr.Zero);
        }
    }
}
