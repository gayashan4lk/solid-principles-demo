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
        private readonly IPolicySerializer serializer;
        private readonly IPolicySource source;
        private readonly ILogger logger;

        public DefaultRatingContext(
            RaterFactory factory, 
            IPolicySerializer serializer,
            IPolicySource source,
            ILogger logger)
        {
            this.factory = factory;
            this.serializer = serializer;
            this.source = source;
            this.logger = logger;
        }

        public Rater CreateRaterForPolicy(Policy policy, RatingEngine engine)
        {
            return factory.Create(policy, engine);
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
