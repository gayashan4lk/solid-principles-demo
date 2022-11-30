using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate()
        {
            logger.Log("Unknown policy type");
        }
    }
}
