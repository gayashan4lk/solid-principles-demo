using ArdalisRating.Core;
using ArdalisRating.Infrastructure;
using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine(
                new ConsoleLogger(),
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory());

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
