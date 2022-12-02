using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class FilePolicySource : IPolicySource
    {
        public string GetDataFromJsonSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
