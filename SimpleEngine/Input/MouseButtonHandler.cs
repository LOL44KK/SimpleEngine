using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEngine.Input
{
    internal class MouseButtonHandler
    {
        private static Mouse.MouseButtonPressedEventHandler? _mouseButtonPressedHandlers;

        internal static void AddMouseButtonPressedHandler(Mouse.MouseButtonPressedEventHandler handler)
        {
            _mouseButtonPressedHandlers += handler;
        }

        internal static void HandleButtonPress()
        {
            MouseButton? pressedButton = DetermineMouseButtonPressed();

            if (pressedButton.HasValue && _mouseButtonPressedHandlers != null)
            {
                _mouseButtonPressedHandlers.Invoke(pressedButton.Value);
            }
        }

        private static MouseButton? DetermineMouseButtonPressed()
        {
            if (Mouse.IsMouseButtonPressed(MouseButton.LeftMouseButton))
            {
                return MouseButton.LeftMouseButton;
            }
            if (Mouse.IsMouseButtonPressed(MouseButton.RightMouseButton))
            {
                return MouseButton.RightMouseButton;
            }
            if (Mouse.IsMouseButtonPressed(MouseButton.MiddleMouseButton))
            {
                return MouseButton.MiddleMouseButton;
            }
            return null;
        }
    }
}
