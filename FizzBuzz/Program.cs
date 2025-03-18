using FizzBuzz;

namespace FizzBuzz
{
    class Program
    {
        private static void Main(string[] args)
        {
            var input = "1 2 &*! 3 4 %%% 5 6";

            var detector = new FizzBuzzDetector();
            var result = detector.GetOverlappings(input);
            Console.WriteLine("output string: ");
            Console.WriteLine(result.OutputString);
            Console.WriteLine("count: " + result.Count);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}