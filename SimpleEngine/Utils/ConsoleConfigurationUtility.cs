using System.Runtime.InteropServices;

namespace SimpleEngine.Utils
{
    public class ConsoleConfigurationUtility
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern nint GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(nint hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(nint hConsoleHandle, uint dwMode);

        private const int STD_INPUT_HANDLE = -10;
        private const uint ENABLE_QUICK_EDIT_MODE = 0x0040;
        private const uint ENABLE_EXTENDED_FLAGS = 0x0080;

        public static void DisableQuickEditMode()
        {
            nint consoleHandle = GetStdHandle(STD_INPUT_HANDLE);

            GetConsoleMode(consoleHandle, out uint consoleMode);

            consoleMode &= ~ENABLE_QUICK_EDIT_MODE;

            SetConsoleMode(consoleHandle, consoleMode | ENABLE_EXTENDED_FLAGS);
        }

        public static void Init()
        {
            AllocConsole();
            Console.CursorVisible = false;
            DisableQuickEditMode();
        }
    }
}
