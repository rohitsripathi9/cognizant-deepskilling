namespace SingletonPatternExample
{
    /// <summary>
    /// Test class that verifies only one instance of Logger is created
    /// and used across the application, demonstrating the Singleton pattern.
    /// </summary>
    public class LoggerTest
    {
        public static void RunTests()
        {
            Console.WriteLine("=== Singleton Pattern - Logger Test ===\n");

            // Test 1: Get Logger instance and verify it logs
            Console.WriteLine("--- Test 1: Basic Logging ---");
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Application started.");
            logger1.LogInfo("Loading configuration...");

            // Test 2: Get another reference and verify it's the same instance
            Console.WriteLine("\n--- Test 2: Single Instance Verification ---");
            Logger logger2 = Logger.GetInstance();
            logger2.LogWarning("Low memory detected.");
            logger2.LogError("Failed to connect to database.");

            // Step 4: Verify both references point to the same instance
            Console.WriteLine("\n--- Test 3: Instance Equality Check ---");
            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("✅ SUCCESS: logger1 and logger2 are the SAME instance.");
                Console.WriteLine($"   logger1 HashCode: {logger1.GetHashCode()}");
                Console.WriteLine($"   logger2 HashCode: {logger2.GetHashCode()}");
            }
            else
            {
                Console.WriteLine("❌ FAILURE: logger1 and logger2 are DIFFERENT instances.");
            }

            // Test 4: Multiple classes using the singleton
            Console.WriteLine("\n--- Test 4: Multiple Classes Using Singleton ---");
            SimulateOrderService();
            SimulatePaymentService();

            Console.WriteLine("\n=== All Tests Completed ===");
        }

        private static void SimulateOrderService()
        {
            Logger logger = Logger.GetInstance();
            logger.LogInfo("OrderService: Processing order #1001.");
        }

        private static void SimulatePaymentService()
        {
            Logger logger = Logger.GetInstance();
            logger.LogInfo("PaymentService: Payment of $250.00 processed successfully.");
        }
    }
}
