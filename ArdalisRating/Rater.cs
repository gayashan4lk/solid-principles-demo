using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public virtual void Rate()
        {
            logger.Log("Unknown policy type");
            engine.Rating = 0m;
        }
    }
}
