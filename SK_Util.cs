using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Skeleton_Key
{
    static class SK_Util
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public static void pasteText(string s)
        {
            char[] chars = s.ToCharArray();
            foreach (char c in chars)
            {
                if (c == '+' || c == '%' || c == '^' || c == '~' || c == '(' || c == ')' || c == '{' || c == '}')
                {
                    SendKeys.SendWait("{" + c + "}");
                }
                else if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                        SendKeys.SendWait("+" + c);
                    else
                        SendKeys.SendWait(c + "");
                }
                else
                    SendKeys.SendWait(c + "");
            }
        }
    }

    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int key;
        private int keyModifier;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.keyModifier = 0;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public KeyHandler(Keys key, int keyModifier, Form form)
        {

            this.key = (int)key;
            this.keyModifier = (int)keyModifier;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, keyModifier, key);
        }

        public bool Unregiser()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
