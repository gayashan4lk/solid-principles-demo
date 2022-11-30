using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class RaterFactory
    {
        public Rater Create(RatingEngine engine)
        {
            switch (engine.policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);

                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);

                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);

                default:
                    // Todo: implement null object pattern
                    // Logger.Log("Unknown policy type");
                    return new Rater(engine, engine.Logger);
            }
        }
    }
}
