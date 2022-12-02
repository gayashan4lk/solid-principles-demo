using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var defaultRatingContext = new DefaultRatingContext(
                new RaterFactory(),
                new JsonPolicySerializer(),
                new FilePolicySource(),
                new ConsoleLogger()
                );

            var engine = new RatingEngine(defaultRatingContext);
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
