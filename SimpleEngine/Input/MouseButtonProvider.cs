using System.Runtime.InteropServices;

namespace SimpleEngine.Input
{
    internal class MouseButtonProvider
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        private static bool[] previousStates = new bool[3];
        private static bool[] currentStates = new bool[3];

        public static bool IsMouseButtonPressed(MouseButton button)
        {
            int index = GetButtonIndex(button);
            if (index == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(button), "Invalid mouse button value");
            }

            currentStates[index] = GetAsyncKeyState((int)button) != 0;

            bool isPressed = currentStates[index] && !previousStates[index];

            previousStates[index] = currentStates[index];

            return isPressed;
        }

        private static int GetButtonIndex(MouseButton button)
        {
            return button switch
            {
                MouseButton.LeftMouseButton => 0,
                MouseButton.RightMouseButton => 1,
                MouseButton.MiddleMouseButton => 2,
                _ => -1
            };
        }
    }
}