using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class AutoPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate()
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(engine.policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return;
            }
            if (engine.policy.Make == "BMW")
            {
                if (engine.policy.Deductible < 500)
                {
                    engine.Rating = 1000m;
                }
                engine.Rating = 900m;
            }
        }
    }
}
