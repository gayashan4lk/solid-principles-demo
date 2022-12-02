using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class RatingUpdater : IRatingUpdater
    {
        private readonly RatingEngine engine;

        public RatingUpdater(RatingEngine engine)
        {
            this.engine = engine;
        }

        public void UpdateRating(decimal rating)
        {
            engine.Rating = rating;
        }
    }
}
