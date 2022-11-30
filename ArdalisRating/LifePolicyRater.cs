using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class LifePolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public LifePolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate()
        {
            logger.Log("Rating LIFE policy...");
            logger.Log("Validating policy.");
            if (engine.policy.DateOfBirth == DateTime.MinValue)
            {
                logger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (engine.policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                logger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (engine.policy.Amount == 0)
            {
                logger.Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - engine.policy.DateOfBirth.Year;
            if (engine.policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < engine.policy.DateOfBirth.Day ||
                DateTime.Today.Month < engine.policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = engine.policy.Amount * age / 200;
            if (engine.policy.IsSmoker)
            {
                engine.Rating = baseRate * 2;
                return;
            }
            engine.Rating = baseRate;
        }
    }
}
