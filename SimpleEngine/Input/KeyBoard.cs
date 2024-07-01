namespace SimpleEngine.Input
{
    public class KeyBoard
    {
        public delegate void InputKeyBoardDelegate(ConsoleKeyInfo key);

        private static InputKeyBoardDelegate? _inputKeyBoardHandlers;

        public static void AddHandler(InputKeyBoardDelegate inputKeyBoardHandler)
        {
            _inputKeyBoardHandlers += inputKeyBoardHandler;
        }

        internal static void HandleKeyPress()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (_inputKeyBoardHandlers != null)
                {
                    _inputKeyBoardHandlers.Invoke(key);
                }
            }
        }
    }
}
