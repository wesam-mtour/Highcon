using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highcon.Infra
{
    internal class Utils
    {
        public static int GetNumberOfOccurrencesForStringInList(List<string> jobsNames, string jobName)
        {
            return jobsNames.Count(str => str == jobName);
        }
    }
}
