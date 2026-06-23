using System;

namespace ECommerceSearch
{
    public class Product : IComparable<Product>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(string productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return string.Compare(this.ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"[ID: {ProductId,-6} | Name: {ProductName,-27} | Category: {Category,-15}]";
        }
    }

    public class SearchEngine
    {
        public static (Product? product, int comparisons) LinearSearch(Product[] products, string targetName)
        {
            int comparisons = 0;
            for (int i = 0; i < products.Length; i++)
            {
                comparisons++;
                if (string.Equals(products[i].ProductName, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return (products[i], comparisons);
                }
            }
            return (null, comparisons);
        }

        public static (Product? product, int comparisons) BinarySearch(Product[] products, string targetName)
        {
            int comparisons = 0;
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                comparisons++;
                int mid = left + (right - left) / 2;
                int cmp = string.Compare(products[mid].ProductName, targetName, StringComparison.OrdinalIgnoreCase);

                if (cmp == 0)
                {
                    return (products[mid], comparisons);
                }
                else if (cmp < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return (null, comparisons);
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                    E-COMMERCE PLATFORM SEARCH ENGINE TESTS                    ");
            Console.WriteLine("===============================================================================");

            Product[] catalog = new Product[]
            {
                new Product("P100", "Laptop Dell XPS", "Electronics"),
                new Product("P101", "Apple iPhone 15", "Electronics"),
                new Product("P102", "Samsung Galaxy S24", "Electronics"),
                new Product("P103", "Sony WH-1000XM5 Headphones", "Audio"),
                new Product("P104", "Nike Air Max Sneakers", "Footwear"),
                new Product("P105", "Adidas Ultraboost", "Footwear"),
                new Product("P106", "Leather Wallet", "Accessories"),
                new Product("P107", "Stainless Steel Water Bottle", "Home & Kitchen"),
                new Product("P108", "Mechanical Keyboard", "Electronics"),
                new Product("P109", "Ergonomic Office Chair", "Furniture")
            };

            Console.WriteLine("\n--- Unsorted Product Catalog (used for Linear Search) ---");
            foreach (var p in catalog)
            {
                Console.WriteLine($"  {p}");
            }

            Product[] sortedCatalog = (Product[])catalog.Clone();
            Array.Sort(sortedCatalog);

            Console.WriteLine("\n--- Sorted Product Catalog (used for Binary Search) ---");
            foreach (var p in sortedCatalog)
            {
                Console.WriteLine($"  {p}");
            }

            string[] testTargets = { "Sony WH-1000XM5 Headphones", "Laptop Dell XPS", "Nonexistent Item" };

            Console.WriteLine("\n===============================================================================");
            Console.WriteLine("                            SEARCH DEMONSTRATION                               ");
            Console.WriteLine("===============================================================================");

            foreach (var target in testTargets)
            {
                Console.WriteLine($"\nSearching for: \"{target}\"");
                
                var (linResult, linComps) = LinearSearch(catalog, target);
                Console.ForegroundColor = linResult != null ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("  [Linear Search] ");
                Console.ResetColor();
                Console.WriteLine($"Found: {(linResult != null ? linResult.ToString() : "Not Found")}");
                Console.WriteLine($"  Comparisons made: {linComps}");

                var (binResult, binComps) = BinarySearch(sortedCatalog, target);
                Console.ForegroundColor = binResult != null ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("  [Binary Search] ");
                Console.ResetColor();
                Console.WriteLine($"Found: {(binResult != null ? binResult.ToString() : "Not Found")}");
                Console.WriteLine($"  Comparisons made: {binComps}");
                
                int saving = linComps - binComps;
                if (saving > 0)
                {
                    Console.WriteLine($"  -> Binary Search was {linComps / (double)binComps:F1}x faster ({saving} fewer comparisons).");
                }
                else if (saving < 0)
                {
                    Console.WriteLine($"  -> Linear Search happened to take fewer comparisons in this specific layout.");
                }
                else
                {
                    Console.WriteLine($"  -> Both methods took equal comparisons ({linComps}).");
                }
            }
            Console.WriteLine("===============================================================================\n");
        }
    }
}
