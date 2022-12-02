using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater ratingUpdater;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            this.ratingUpdater = ratingUpdater;
        }
        
        public abstract void Rate(Policy policy);
    }
}
