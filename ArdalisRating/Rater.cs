using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly RatingEngine engine;
        protected readonly ConsoleLogger logger;

        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }
        
        public abstract void Rate();
    }
}
