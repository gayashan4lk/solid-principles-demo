using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger logger;
        private readonly IPolicySource policySource;
        private readonly IPolicySerializer serializer;
        private readonly RaterFactory raterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(
            ILogger logger,
            IPolicySource policySource,
            IPolicySerializer serializer,
            RaterFactory raterFactory)
        {
            this.logger = logger;
            this.policySource = policySource;
            this.serializer = serializer;
            this.raterFactory = raterFactory;
        }

        public void Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");

            string policyData = policySource.GetDataFromJsonSource();

            var policy = serializer.GetPolicyFromJsonString(policyData);
            
            var rater = raterFactory.Create(policy);
            
            Rating = rater.Rate(policy);

            logger.Log("Rating completed.");
        }
    }
}
