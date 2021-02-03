using System;

namespace PatternsAndConcepts.Patterns.Creational
{
    /// <summary>
    /// Allows only a single thread to enter the critical area,
    /// which the lock block identifies, when no instance of
    /// ThreadSafeSingleton has yet been created
    /// For more infor please see https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN#multithreaded-singleton
    /// </summary>
    public sealed class ThreadSafeSingleton
    {
        private static volatile ThreadSafeSingleton instance;
        private static object syncRoot = new Object();

        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ThreadSafeSingleton();
                    }
                }

                return instance;
            }
        }
    }
}
