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
        public decimal Rating { get; set; }

        public Policy? policy { get; set; }

        /// <summary>
        /// Logging - Handles logging.
        /// </summary>
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        /// <summary>
        /// Persistence - Handles getting data from json file.
        /// </summary>
        private FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        /// <summary>
        /// Encoding Format - Handles convert json string to policy object.
        /// </summary>
        private JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            string policyJson = PolicySource.GetDataFromJsonSource();

            policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var raterFactory = new RaterFactory();

            var rater = raterFactory.Create(this);
            rater.Rate();

            Logger.Log("Rating completed.");
        }
    }
}
