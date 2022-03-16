using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Drawing
{
    public class ScreenCapturer
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public Bitmap Capture(enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window)
        {
            Rectangle bounds;

            var captureBmp = new Bitmap(1920, 1024, PixelFormat.Format32bppArgb);
            using (var captureGraphic = Graphics.FromImage(captureBmp))
            {
                captureGraphic.CopyFromScreen(0, 0, 0, 0, captureBmp.Size);
                captureBmp.Save("capture.jpg", ImageFormat.Jpeg);
            }

            /*if (screenCaptureMode == enmScreenCaptureMode.Screen)
            {
                bounds = Screen.GetBounds(Point.Empty);
                CursorPosition = Cursor.Position;
            }
            else if (screenCaptureMode == enmScreenCaptureMode.AllScreens)
            {
                int minX, minY;
                int maxX, maxY;
                minX = minY = maxX = maxY = 0;

                foreach (var scr in Screen.AllScreens)
                {
                    if (minX > scr.Bounds.Left) minX = scr.Bounds.Left;
                    if (minY > scr.Bounds.Top) minY = scr.Bounds.Top;
                    if (maxX < scr.Bounds.Right) minX = scr.Bounds.Right;
                    if (maxY < scr.Bounds.Bottom) minY = scr.Bounds.Bottom;
                }

                bounds = new Rectangle(0, 0, Math.Abs(minX) + maxX, Math.Abs(minY) + maxY);
            }
            else
            {
                var foregroundWindowsHandle = GetForegroundWindow();
                var rect = new Rect();
                GetWindowRect(foregroundWindowsHandle, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
            }

            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var g = Graphics.FromImage(result))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;*/
            return null;
        }

        public Point CursorPosition
        {
            get;
            protected set;
        }

    }
}
