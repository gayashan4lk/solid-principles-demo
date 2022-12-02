using ArdalisRating.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Core
{
    public class RaterFactory
    {
        public Rater Create(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), 
                    new object[] {});
            }
            catch
            {
                return new UnknownPolicyRater();
            }
        }
    }
}
