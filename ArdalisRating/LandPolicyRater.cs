using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class LandPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public LandPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate()
        {
            logger.Log("Rating LAND policy...");
            logger.Log("Validating policy.");
            if (engine.policy.BondAmount == 0 || engine.policy.Valuation == 0)
            {
                logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (engine.policy.BondAmount < 0.8m * engine.policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return;
            }
            engine.Rating = engine.policy.BondAmount * 0.05m;
        }
    }
}
