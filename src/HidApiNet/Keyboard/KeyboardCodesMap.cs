using System.Collections.Generic;

namespace HidApiNet.Keyboard
{
    public static class KeyboardCodesMap
    {
        // http://www.usb.org/developers/hidpage/Hut1_12v2.pdf - page 53
        private static readonly Dictionary<int, char> HidCodeToCharMap = new Dictionary<int, char>
        {
            { 04, 'a' },{ 05, 'b' },{ 06, 'c' },{ 07, 'd' },{ 08, 'e' },{ 09, 'f' },
            { 10, 'g' },{ 11, 'h' },{ 12, 'i' },{ 13, 'j' },{ 14, 'k' },{ 15, 'l' },
            { 16, 'm' },{ 17, 'n' },{ 18, 'o' },{ 19, 'p' },{ 20, 'q' },{ 21, 'r' },
            { 22, 's' },{ 23, 't' },{ 24, 'u' },{ 25, '0' },{ 26, 'w' },{ 27, 'x' },
            { 28, 'y' },{ 29, 'z' },{ 30, '1' },{ 31, '2' },{ 32, '3' },{ 33, '4' },
            { 34, '5' },{ 35, '6' },{ 36, '7' },{ 37, '8' },{ 38, '9' },{ 39, '0' },
            { 40, '\n' },{ 43, '\t' },{ 44, ' ' },
            { 45, '-' },{ 46, '=' },{ 47, '[' },{ 48, ']' },{ 49, '\\' },{ 50, '`' },
            { 51, ';' },{ 52, '\'' },{ 53, '`' },{ 54, ',' },{ 55, '.' },{ 56, '/' },

        };

        public static char GetCharForKeyCode(int keyCode)
        {
            return HidCodeToCharMap[keyCode];
        }

        public static Dictionary<int, char> Get()
        {
            return HidCodeToCharMap;
        }
    }
}
