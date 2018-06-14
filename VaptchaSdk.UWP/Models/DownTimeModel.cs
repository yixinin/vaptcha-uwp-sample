using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaptchaSdk.UWP.Models
{
    public class DownTimeModel
    {
        public long time { get; set; }
        public string url { get; set; }
    }
    public class VaptchaModel
    {
        public bool isDown { get; set; } 
        public ChallengeModel challenge { get; set; }
    }
    
}
