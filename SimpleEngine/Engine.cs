namespace SimpleEngine
{
    public class Engine
    {
        public static void Run()
        {
            while (true)
            {
                Input.KeyBoard.Handel();
                Input.Mouse.Handel();
            }
        }
    }
}
