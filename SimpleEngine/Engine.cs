namespace SimpleEngine
{
    public class Engine
    {
        public static void Run()
        {
            while (true)
            {
                Input.KeyBoard.HandleKeyPress();

                Input.MouseButtonHandler.HandleButtonPress();
            }
        }
    }
}
