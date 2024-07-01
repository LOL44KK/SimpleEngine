using System.Drawing;

namespace SimpleEngine.Input
{
    public class Mouse
    {
        public static Point GetCursorPosition() => MousePositionProvider.GetCursorPosition();
        public static Point GetCursorCharacterPosition() => MousePositionProvider.GetCursorCharacterPosition();
        public static bool IsMouseButtonPressed(MouseButton button) => MouseButtonProvider.IsMouseButtonPressed(button);


        public delegate void MouseButtonPressedEventHandler(MouseButton pressedButton);
        public static void AddMouseButtonPressedHandler(MouseButtonPressedEventHandler handler)
        {
            MouseButtonHandler.AddMouseButtonPressedHandler(handler);
        }
    }
}