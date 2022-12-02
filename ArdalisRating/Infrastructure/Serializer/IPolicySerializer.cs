using ArdalisRating.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Infrastructure
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string jsonString);
    }
}
