namespace TestSimpleEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleEngine.Input.KeyBoard.AddHandler(Test);
            SimpleEngine.Input.Mouse.AddMouseButtonPressedHandler(Test2);
            SimpleEngine.Engine.Run();
        }

        static void Test(ConsoleKeyInfo key)
        {
            Console.WriteLine(key);
        }

        static void Test2(SimpleEngine.Input.MouseButton button)
        {
            Console.WriteLine(button);
        }
    }
}
