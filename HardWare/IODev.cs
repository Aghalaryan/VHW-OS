using System;


namespace HW
{
    namespace IO_Devices
    {
        public static class Monitor
        {
            
            public static void scan(string s)
            {
                s = Console.ReadLine();
            }
        }

        public static class Keyboard
        {
            public static void print(string s)
            {
                Console.WriteLine(s);

            }

        }
    }
}