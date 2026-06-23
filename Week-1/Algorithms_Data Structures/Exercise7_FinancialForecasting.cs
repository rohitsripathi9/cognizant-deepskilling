using System;

namespace FinancialForecasting
{
    public class Forecaster
    {
        public static double PredictFutureValueRecursive(double currentValue, double[] growthRates, int yearIndex)
        {
            if (yearIndex >= growthRates.Length)
            {
                return currentValue;
            }

            double nextValue = currentValue * (1 + growthRates[yearIndex]);
            return PredictFutureValueRecursive(nextValue, growthRates, yearIndex + 1);
        }

        public static double PredictConstantGrowthRecursive(double currentValue, double annualRate, int years)
        {
            if (years <= 0)
            {
                return currentValue;
            }

            return PredictConstantGrowthRecursive(currentValue * (1 + annualRate), annualRate, years - 1);
        }

        public static double PredictFutureValueIterative(double initialValue, double[] growthRates)
        {
            double value = initialValue;
            for (int i = 0; i < growthRates.Length; i++)
            {
                value *= (1 + growthRates[i]);
            }
            return value;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                         FINANCIAL FORECASTING SYSTEM                          ");
            Console.WriteLine("===============================================================================");

            double initialInvestment = 10000.00;
            
            double[] growthRates = { 0.05, 0.07, -0.03, 0.06, 0.08 };

            Console.WriteLine($"Initial Investment: {initialInvestment:C}");
            Console.WriteLine("Forecasted Annual Growth Rates:");
            for (int i = 0; i < growthRates.Length; i++)
            {
                Console.WriteLine($"  Year {i + 1}: {growthRates[i]:P1}");
            }

            Console.WriteLine("\n--- Calculating Future Value ---");

            double recursiveResult = PredictFutureValueRecursive(initialInvestment, growthRates, 0);
            Console.Write("  [Recursive Approach] Future Value: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{recursiveResult:C}");
            Console.ResetColor();

            double iterativeResult = PredictFutureValueIterative(initialInvestment, growthRates);
            Console.Write("  [Iterative Approach] Future Value: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{iterativeResult:C}");
            Console.ResetColor();

            Console.WriteLine("\n--- Constant Growth Rate Scenario (e.g. 6% annually for 15 years) ---");
            double constantRate = 0.06;
            int years = 15;
            double constRecursive = PredictConstantGrowthRecursive(initialInvestment, constantRate, years);
            
            Console.WriteLine($"Forecast for {years} years at {constantRate:P0} constant growth:");
            Console.Write("  Result: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{constRecursive:C}");
            Console.ResetColor();

            Console.WriteLine("===============================================================================\n");
        }
    }
}
