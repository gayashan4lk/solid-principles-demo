using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }

        private readonly RaterFactory factory;
        private readonly JsonPolicySerializer serializer;
        private readonly FilePolicySource source;
        private readonly ILogger logger;

        public DefaultRatingContext(
            RaterFactory factory, 
            JsonPolicySerializer serializer,
            FilePolicySource source,
            ILogger logger)
        {
            this.factory = factory;
            this.serializer = serializer;
            this.source = source;
            this.logger = logger;
        }

        public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            return factory.Create(policy, this);
        }

        public Policy GetPolicyFromJsonString(string jsonString)
        {
            return serializer.GetPolicyFromJsonString(jsonString);
        }

        public Policy GetPolicyFromXmlString(string xmlString)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile()
        {
            return source.GetDataFromJsonSource();
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            logger.Log(message);
        }
    }
}
