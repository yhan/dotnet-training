using System;
using System.Threading;

namespace Process2
{
    /// <summary>
    /// Own a Mutex
    /// 
    /// A Mutex object can be owned by a thread. When owned, it can only be owned by one single thread.
    /// When it is owned by a thread, other threads cannot own it until the original thread owner releases it.
    /// A thread which wants to own a Mutex calls the Mutex instance's WaitOne() method.
    /// An owning thread which wants to release the Mutex calls the ReleaseMutex() method.
    ///
    /// My conclusion:
    /// Should systematically Wait before release, for ensuring the current thread owns the mutext
    ///
    /// *****
    /// cf: docs.microsoft:
    ///
    /// Mutexes have thread affinity;
    /// that is, the mutex can be released only by the thread that owns it.
    /// If a thread releases a mutex it does not own, an ApplicationException is thrown in the thread.
    /// 
    /// </summary>
    class SecondProcess
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("2nd process");

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
