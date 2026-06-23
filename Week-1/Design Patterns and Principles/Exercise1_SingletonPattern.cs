using System;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();

        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        public static Logger GetInstance()
        {
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Exercise 1: Singleton Pattern Verification ---");

            Console.WriteLine("Retrieving Logger instance 1...");
            Logger logger1 = Logger.GetInstance();

            Console.WriteLine("Retrieving Logger instance 2...");
            Logger logger2 = Logger.GetInstance();

            logger1.Log("Message from logger1 instance.");
            logger2.Log("Message from logger2 instance.");

            bool isSameInstance = ReferenceEquals(logger1, logger2);
            Console.WriteLine("\nVerification Result:");
            Console.WriteLine("Are both logger instances the same? " + isSameInstance);

            if (isSameInstance)
            {
                Console.WriteLine("SUCCESS: Singleton Pattern works. Only one instance of Logger exists.");
            }
            else
            {
                Console.WriteLine("FAILURE: Multiple Logger instances detected.");
            }
        }
    }
}
