using System.Runtime.InteropServices;

namespace SimpleEngine
{
    public class Class1
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        static public void Test()
        {
            AllocConsole();
            Console.WriteLine("asd");
        }
    }
}
