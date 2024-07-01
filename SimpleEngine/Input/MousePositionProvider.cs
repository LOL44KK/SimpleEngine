using System.Drawing;
using System.Runtime.InteropServices;

namespace SimpleEngine.Input
{
    internal class MousePositionProvider
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleScreenBufferInfo(IntPtr hConsoleOutput, out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);

        [StructLayout(LayoutKind.Sequential)]
        private struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SMALL_RECT
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CONSOLE_SCREEN_BUFFER_INFO
        {
            public COORD dwSize;
            public COORD dwCursorPosition;
            public short wAttributes;
            public SMALL_RECT srWindow;
            public COORD dwMaximumWindowSize;
        }

        private const int STD_OUTPUT_HANDLE = -11;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        public static Point GetCursorPosition()
        {
            POINT p;
            GetCursorPos(out p);
            return new Point(p.X, p.Y);
        }

        public static Point GetCursorCharacterPosition()
        {
            POINT p;
            GetCursorPos(out p);
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow == IntPtr.Zero)
            {
                throw new InvalidOperationException("Could not get console window handle.");
            }
            ScreenToClient(consoleWindow, ref p);

            CONSOLE_SCREEN_BUFFER_INFO csbi;
            IntPtr hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleScreenBufferInfo(hConsoleOutput, out csbi))
            {
                throw new InvalidOperationException("Could not get console screen buffer info.");
            }

            RECT rect;
            GetClientRect(consoleWindow, out rect);
            int windowWidth = rect.Right - rect.Left;
            int windowHeight = rect.Bottom - rect.Top;

            float charWidth = (float)windowWidth / (csbi.srWindow.Right - csbi.srWindow.Left + 1);
            float charHeight = (float)windowHeight / (csbi.srWindow.Bottom - csbi.srWindow.Top + 1);

            int cursorColumn = (int)((p.X - rect.Left) / charWidth);
            int cursorRow = (int)((p.Y - rect.Top) / charHeight);

            return new Point(cursorColumn, cursorRow);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
    }
}
