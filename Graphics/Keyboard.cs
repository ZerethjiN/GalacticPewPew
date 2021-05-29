using SFML.Window;

namespace AlizeeEngine {
    public class Clavier {

        public enum Touche {
            A = Keyboard.Key.A, B = Keyboard.Key.B, C = Keyboard.Key.C, D = Keyboard.Key.D, E = Keyboard.Key.E,
            F = Keyboard.Key.F, G = Keyboard.Key.G, H = Keyboard.Key.H, I = Keyboard.Key.I, J = Keyboard.Key.J,
            K = Keyboard.Key.K, L = Keyboard.Key.L, M = Keyboard.Key.M, N = Keyboard.Key.N, O = Keyboard.Key.O,
            P = Keyboard.Key.P, Q = Keyboard.Key.Q, R = Keyboard.Key.R, S = Keyboard.Key.S, T = Keyboard.Key.T,
            U = Keyboard.Key.U, V = Keyboard.Key.V, W = Keyboard.Key.W, X = Keyboard.Key.X, Y = Keyboard.Key.Y,
            Z = Keyboard.Key.Z,
            Num0 = Keyboard.Key.Num0, Num1 = Keyboard.Key.Num1, Num2 = Keyboard.Key.Num2,
            Num3 = Keyboard.Key.Num3, Num4 = Keyboard.Key.Num4, Num5 = Keyboard.Key.Num5,
            Num6 = Keyboard.Key.Num6, Num7 = Keyboard.Key.Num7, Num8 = Keyboard.Key.Num8,
            Num9 = Keyboard.Key.Num9,
            Escape = Keyboard.Key.Escape,
            LControl = Keyboard.Key.LControl, LShift = Keyboard.Key.LShift, LAlt = Keyboard.Key.LAlt,
            LSystem = Keyboard.Key.LSystem, LBracket = Keyboard.Key.LBracket,
            RControl = Keyboard.Key.RControl, RShift = Keyboard.Key.RShift, RAlt = Keyboard.Key.RAlt,
            RSystem = Keyboard.Key.RSystem, RBracket = Keyboard.Key.RBracket,
            Menu = Keyboard.Key.Menu,
            Semicolon = Keyboard.Key.Semicolon, Comma = Keyboard.Key.Comma, Period = Keyboard.Key.Period,
            Quote = Keyboard.Key.Quote, Slash = Keyboard.Key.Slash, Backslash = Keyboard.Key.Backslash,
            Tilde = Keyboard.Key.Tilde, Equal = Keyboard.Key.Equal, Hyphen = Keyboard.Key.Hyphen,
            Space = Keyboard.Key.Space, Enter = Keyboard.Key.Enter, Backspace = Keyboard.Key.Backspace,
            Tab = Keyboard.Key.Tab, PageUp = Keyboard.Key.PageUp, PageDown = Keyboard.Key.PageDown,
            End = Keyboard.Key.End, Home = Keyboard.Key.Home, Insert = Keyboard.Key.Insert,
            Delete = Keyboard.Key.Delete, Add = Keyboard.Key.Add,
            Subtract = Keyboard.Key.Subtract, Multiply = Keyboard.Key.Multiply, Divide = Keyboard.Key.Divide,
            Left = Keyboard.Key.Left, Right = Keyboard.Key.Right, Up = Keyboard.Key.Up, Down = Keyboard.Key.Down,
            Numpad0 = Keyboard.Key.Numpad0, Numpad1 = Keyboard.Key.Numpad1, Numpad2 = Keyboard.Key.Numpad2,
            Numpad3 = Keyboard.Key.Numpad3, Numpad4 = Keyboard.Key.Numpad4, Numpad5 = Keyboard.Key.Numpad5,
            Numpad6 = Keyboard.Key.Numpad6, Numpad7 = Keyboard.Key.Numpad7, Numpad8 = Keyboard.Key.Numpad8,
            Numpad9 = Keyboard.Key.Numpad9,
            F1 = Keyboard.Key.F1, F2 = Keyboard.Key.F2, F3 = Keyboard.Key.F3, F4 = Keyboard.Key.F4,
            F5 = Keyboard.Key.F5, F6 = Keyboard.Key.F6, F7 = Keyboard.Key.F7, F8 = Keyboard.Key.F8,
            F9 = Keyboard.Key.F9, F10 = Keyboard.Key.F10, F11 = Keyboard.Key.F11, F12 = Keyboard.Key.F12,
            F13 = Keyboard.Key.F13, F14 = Keyboard.Key.F14, F15 = Keyboard.Key.F15,
            Pause = Keyboard.Key.Pause, KeyCount = Keyboard.Key.KeyCount
        }

        public bool IsKeyPressed(Touche touche) {
            return Keyboard.IsKeyPressed((Keyboard.Key) touche);
        }

    }
}