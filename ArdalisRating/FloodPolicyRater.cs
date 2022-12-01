using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate()
        {
            logger.Log("Rating FLOOD policy...");
            logger.Log("Validating policy.");
            if (engine.policy.BondAmount == 0 || engine.policy.Valuation == 0)
            {
                logger.Log("Flood policy must specify Bond Amount and Valuation");
                return;
            }
            if (engine.policy.ElevationAboveSeaLevelFeet <= 0)
            {
                logger.Log("Flood policy is not available for elevations at or below sea level.");
                return;
            }
            if (engine.policy.BondAmount < 0.8m * engine.policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return;
            }
            decimal multiple = 1.0m;
            if (engine.policy.ElevationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            } else if (engine.policy.ElevationAboveSeaLevelFeet < 500)
            {
                multiple = 1.5m;
            }
            else if (engine.policy.ElevationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.1m;
            }
            engine.Rating = engine.policy.BondAmount *  0.05m * multiple;
        }
    }
}
