﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class RaterFactory
    {
        public Rater Create(RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{engine.policy.Type}PolicyRater"), 
                    new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
