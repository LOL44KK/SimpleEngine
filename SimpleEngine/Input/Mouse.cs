using System.Drawing;

namespace SimpleEngine.Input
{
    public enum MouseButton
    {
        LeftMouseButton = 0x01,
        RightMouseButton = 0x02,
        MiddleMouseButton = 0x4,
    }

    public class Mouse
    {
        public delegate void InputMouseButtonDelegate(MouseButton button);

        private static InputMouseButtonDelegate? _inputMouseButtonHandlers;

        public static void AddHandler(InputMouseButtonDelegate inputMouseButtonHandler)
        {
            _inputMouseButtonHandlers += inputMouseButtonHandler;
        }

        internal static void Handel()
        {
            bool leftMouseButton = IsMouseButtonPressed(MouseButton.LeftMouseButton);
            bool rightMouseButton = IsMouseButtonPressed(MouseButton.RightMouseButton);
            bool middleMouseButton = IsMouseButtonPressed(MouseButton.MiddleMouseButton);

            MouseButton? buttonPressed = null;
            if (leftMouseButton)
            {
                buttonPressed = MouseButton.LeftMouseButton;
            }
            else if (rightMouseButton)
            {
                buttonPressed = MouseButton.RightMouseButton;
            }
            else if (middleMouseButton)
            {
                buttonPressed = MouseButton.MiddleMouseButton;
            }

            if (buttonPressed != null && _inputMouseButtonHandlers != null)
            {
                _inputMouseButtonHandlers.Invoke((MouseButton)buttonPressed);
            }
        }

        public static Point GetCursorPosition() => MousePositionProvider.GetCursorPosition();
        public static Point GetCursorCharacterPosition() => MousePositionProvider.GetCursorCharacterPosition();
        public static bool IsMouseButtonPressed(MouseButton button) => MouseButtonProvider.IsMouseButtonPressed(button);
    }
}