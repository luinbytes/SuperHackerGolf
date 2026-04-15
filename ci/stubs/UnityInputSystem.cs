// Compile-time stubs for Unity.InputSystem types used by SuperHackerGolf.
// Empty bodies — compiler-only. Do not use at runtime.

#pragma warning disable CS0626, CS0649, CS0414, CS8618, CS8625

namespace UnityEngine.InputSystem
{
    public enum Key
    {
        None = 0,
        Space, Enter, Tab, Backquote, Quote, Semicolon, Comma, Period,
        Slash, Backslash, LeftBracket, RightBracket, Minus, Equals,
        A, B, C, D, E, F, G, H, I, J, K, L, M,
        N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
        Digit1, Digit2, Digit3, Digit4, Digit5, Digit6, Digit7, Digit8, Digit9, Digit0,
        LeftShift, RightShift, LeftAlt, RightAlt, LeftCtrl, RightCtrl, LeftMeta, RightMeta,
        LeftWindows, RightWindows, LeftApple, RightApple, LeftCommand, RightCommand,
        ContextMenu, Escape, LeftArrow, RightArrow, UpArrow, DownArrow, Backspace,
        PageDown, PageUp, Home, End, Insert, Delete, CapsLock, NumLock, PrintScreen,
        ScrollLock, Pause, NumpadEnter, NumpadDivide, NumpadMultiply, NumpadPlus, NumpadMinus,
        NumpadPeriod, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9,
        F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
        OEM1, OEM2, OEM3, OEM4, OEM5,
    }

    public class InputControl
    {
        public string name => "";
        public string displayName => "";
    }

    public class InputDevice : InputControl { }
}

namespace UnityEngine.InputSystem.Controls
{
    public class ButtonControl : InputControl
    {
        public bool isPressed => false;
        public bool wasPressedThisFrame => false;
        public bool wasReleasedThisFrame => false;
        public float ReadValue() => 0f;
    }

    public class KeyControl : ButtonControl { }
}

namespace UnityEngine.InputSystem
{
    public class Keyboard : InputDevice
    {
        public static Keyboard current => null;
        public UnityEngine.InputSystem.Controls.KeyControl this[Key key] => null;
        public UnityEngine.InputSystem.Controls.ButtonControl anyKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl spaceKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl enterKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl escapeKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl tabKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl leftShiftKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl rightShiftKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl leftCtrlKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl rightCtrlKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl leftAltKey => null;
        public UnityEngine.InputSystem.Controls.KeyControl rightAltKey => null;
    }

    public class Mouse : InputDevice
    {
        public static Mouse current => null;
        public UnityEngine.InputSystem.Controls.ButtonControl leftButton => null;
        public UnityEngine.InputSystem.Controls.ButtonControl rightButton => null;
        public UnityEngine.InputSystem.Controls.ButtonControl middleButton => null;
        public UnityEngine.InputSystem.Controls.ButtonControl backButton => null;
        public UnityEngine.InputSystem.Controls.ButtonControl forwardButton => null;
    }
}
