using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
        }
    }
}
