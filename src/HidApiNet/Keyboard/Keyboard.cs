using System;

namespace HidApiNet.Keyboard
{
    public class Keyboard : HidDevice
    {
        public Keyboard(string path)
            : base(path) { }

        public Keyboard(ushort vid, ushort pid)
            : base(vid, pid) { }

        public string ReadUntil(string s)
        {
            var result = "";

            byte[] readBuffer = new byte[8];
            while (!result.EndsWith(s))
            {
                var bytesRead = Read(readBuffer, 8);
                
                Console.WriteLine($"{bytesRead} bytes read: {BitConverter.ToString(readBuffer)}");

                for (int i = 2; i < bytesRead; i++)
                {
                    var keyCode = readBuffer[i];
                    if (keyCode != 0)
                    {
                        result += KeyboardCodesMap.GetCharForKeyCode(keyCode);
                    }
                }
            }

            return result;
        }
    }
}
