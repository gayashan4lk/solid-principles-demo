using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Infrastructure
{
    public class FilePolicySource : IPolicySource
    {
        public string GetDataFromJsonSource()
        {
            string filePath = @"C:\Users\ErangaGayashanBISTEC\workspaces\csharp-workspace\ArdalisRating\ArdalisRating\policy.json";
            return File.ReadAllText(filePath);
        }
    }
}
