using System;
using System.Threading;

namespace Process1
{
    class FirstProcess
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1st process");

            
            if (!Mutex.TryOpenExisting("mutext", out var mutex))
            {
                Console.WriteLine("Mutex does not exist");
                mutex = new Mutex(initiallyOwned: false, name: "mutex");
            }

            mutex.WaitOne();   // Wait until it is safe to enter.  
            Console.WriteLine($"{DateTime.Now} has entered in the C_sharpcorner.com");  
            // Place code to access non-reentrant resources here.  
            Thread.Sleep(2000);    // Wait until it is safe to enter.  
            
            
            Console.WriteLine($"{DateTime.Now} is leaving the C_sharpcorner.com\r\n");  
          
      
            
            mutex.ReleaseMutex();    // Release the Mutex.  
            mutex.Dispose();

            Console.Read();

        }
    }
}
