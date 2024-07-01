namespace SimpleEngine
{
    public class Engine
    {
        public static void Run()
        {
            while (true)
            {
                Input.KeyBoard.HandelKeyPress();

                Input.MouseButtonHandler.HandleButtonPress();
            }
        }
    }
}
