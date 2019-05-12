using System;
using System.IO.Pipes;
using IOLib;

namespace Client
{
    internal class ClientProgram
    {
        private static void Main(string[] args)
        {
            var pipeClient = new NamedPipeClientStream(".", Common.PipeName, PipeDirection.In, PipeOptions.None);

            pipeClient.Connect();

            var streamString = new StreamString(pipeClient);
            var messageFromServer = streamString.ReadString();

            Console.WriteLine($"Server says: {messageFromServer}");

            pipeClient.Close();

            Console.ReadKey();
        }
    }
}