using System;
using System.IO;
using System.Threading.Tasks;

namespace HW
{
    public static class HDD
    {
        private const string _filePath = "HDD.txt";
        private static FileStream _fileStream;

        public delegate void WriteEventHendler(bool state);
        public static event WriteEventHendler WriteEvent;

        public delegate void ReadEventHendler(bool state);
        public static event ReadEventHendler ReadEvent;


        public static void Init()
        {
            try
            {
                _fileStream = Open(_filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(@"An error occurred during file open process: {ex.Message}");
            }

        }

        public static void Close()
        {
            _fileStream.Close();

        }

        private static FileStream Open(string path)
        {
            return File.Open(path, FileMode.Open, FileAccess.ReadWrite);
        }

        public static async Task Read(byte[] buffer, long offset, long size)
        {

            bool state = true;
            _fileStream.Seek(offset, SeekOrigin.Begin);
            try
            {
                await _fileStream.ReadAsync(buffer, 0, Convert.ToInt32(size));
            }
            catch (Exception ex)
            {
                state = false;
            }


            if (ReadEvent != null)
                ReadEvent(state);


        }


        public static async Task Write(long address, byte[] buff)
        {

            bool state = true;
            _fileStream.Seek(address, SeekOrigin.Begin);
            try
            {
                await _fileStream.WriteAsync(buff, 0, buff.Length);
            }
            catch (Exception ex)
            {
                state = false;
            }

            if (WriteEvent != null)
                WriteEvent(state);


        }


    }
}