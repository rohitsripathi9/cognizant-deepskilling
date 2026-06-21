namespace SingletonPatternExample
{
    /// <summary>
    /// Logger class implementing the Singleton design pattern.
    /// Ensures that only one instance of Logger exists throughout
    /// the application lifecycle for consistent logging.
    /// </summary>
    public class Logger
    {
        // Step 1: Private static instance of itself
        private static Logger? _instance = null;

        // Lock object for thread safety
        private static readonly object _lock = new object();

        // Step 2: Private constructor to prevent external instantiation
        private Logger()
        {
            Console.WriteLine("[Logger] Logger instance created.");
        }

        // Step 3: Public static method to get the single instance
        public static Logger GetInstance()
        {
            // Double-checked locking for thread-safe lazy initialization
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // Logging methods
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}
