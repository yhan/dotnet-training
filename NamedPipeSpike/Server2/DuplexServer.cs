using System;
using System.IO;
using System.IO.Pipes;
using IOLib;

namespace Server2
{
    internal class DuplexServer
    {
        private static void Main(string[] args)
        {
            var pipeServer = new NamedPipeServerStream(Common.PipeName, PipeDirection.InOut, 1);
            pipeServer.WaitForConnection();

            var streamString = new StreamString(pipeServer);

            // Server write to pipe
            streamString.WriteString(Common.Secret);

            // Server wait for client writing, then read it from pipe
            var fileName = streamString.ReadString();

            // Server write content back to pipe
            var content = File.ReadAllText(fileName);
            streamString.WriteString(content);

            pipeServer.Close();
            Console.WriteLine("Server finishes");

            Console.Read();
        }

        private static void Worker()
        {
            throw new NotImplementedException();
        }
    }
}