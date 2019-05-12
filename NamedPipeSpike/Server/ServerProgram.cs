using System;
using System.IO.Pipes;
using IOLib;

namespace Server
{
    internal class ServerProgram
    {
        private static void Main(string[] args)
        {
            var pipeServerStream = new NamedPipeServerStream(Common.PipeName, PipeDirection.Out, 1);
            pipeServerStream.WaitForConnection();

            var streamString = new StreamString(pipeServerStream);

            streamString.WriteString(Common.Secret);

            Console.WriteLine("Server ends");
            pipeServerStream.Close();

            Console.Read();
        }
    }
}