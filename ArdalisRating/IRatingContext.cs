using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string jsonString);
        Policy GetPolicyFromXmlString(string xmlString);
        Rater CreateRaterForPolicy(Policy policy, RatingEngine engine);
        RatingEngine Engine { get; set; }
    }
}
