using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    ratingUpdater.UpdateRating(1000m);
                    return;
                }
                ratingUpdater.UpdateRating(900m);
            }
        }
    }
}
