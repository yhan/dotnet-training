using System;
using System.IO.Pipes;
using IOLib;

namespace Client2
{
    internal class DuplexClient
    {
        private static void Main(string[] args)
        {
            var pipeClient = new NamedPipeClientStream(".", Common.PipeName, PipeDirection.InOut, PipeOptions.None);

            pipeClient.Connect();

            var streamString = new StreamString(pipeClient);

            //Client read content from pipe
            if (streamString.ReadString() == Common.Secret)
            {
                // Client write content to pipe
                streamString.WriteString("E:\\Projects\\git\\NamedPipeSpike\\message.txt");
            }

            // Client read content again, expecting server has written at this moment to the pipe
            Console.WriteLine($"Server send back file content: {streamString.ReadString()}");
            Console.ReadKey();
        }
    }
}