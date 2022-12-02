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
        private readonly IRatingContext context;

        public decimal Rating { get; set; }

        public RatingEngine(IRatingContext context)
        {
            this.context = context;
        }

        public void Rate()
        {
            context.Log("Starting rate.");
            context.Log("Loading policy.");

            string policyJson = context.LoadPolicyFromFile();

            var policy = context.GetPolicyFromJsonString(policyJson);
            
            var rater = context.CreateRaterForPolicy(policy, this);
            
            rater.Rate(policy);

            context.Log("Rating completed.");
        }
    }
}
