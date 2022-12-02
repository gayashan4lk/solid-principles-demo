using ArdalisRating.Core.Models;
using ArdalisRating.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Core
{
    public abstract class Rater
    {
        public ILogger Logger { get; set; } = new ConsoleLogger();
        
        public abstract decimal Rate(Policy policy);
    }
}
