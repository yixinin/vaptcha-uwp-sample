using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaptchaSdk.UWP.Models
{
    public class ChallengeModel
    {
        public string id { get; set; }
        public string challenge { get; set; }
    }
    public class TokenModel
    {
        public string token { get; set; }
        public string challenge { get; set; }
    }
}
