namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"temp\example.png";
            string bytesFilePath = @"temp\bytes.txt";
            string outputPath = @"temp\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using var sr = new StreamReader(bytesFilePath);
            HashSet<byte> bytesToCheck = new HashSet<byte>();

            while (!sr.EndOfStream)
            {
                bytesToCheck.Add(byte.Parse(sr.ReadLine()));
            }

            using FileStream fileStreamReader = new FileStream(binaryFilePath, FileMode.Open);

            byte[] buffer = new byte[fileStreamReader.Length];

            fileStreamReader.Read(buffer);

            using FileStream fileStreamWriter = new FileStream(outputPath, FileMode.Create);

            List<byte> bufferForWrite = new List<byte>(buffer.Length);

            int count = 0;

            foreach (byte byteInBuffer in buffer)
            {
                foreach (byte byteToCheck in bytesToCheck)
                {
                    if (byteToCheck == byteInBuffer)
                    {
                        bufferForWrite.Add(byteToCheck);
                        break;
                    }
                }
            }

            fileStreamWriter.Write(bufferForWrite.ToArray());
        }
    }
}