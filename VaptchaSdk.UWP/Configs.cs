using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaptchaSdk.UWP
{
    public class Configs
    {
        public static readonly string vaptcha_url = "https://m.vaptcha.com/app/uwp/popup.html";
        
        public static readonly string validate_url = "https://m.vaptcha.com/api/vaptcha/validate/uwp";
        public static readonly string validate_down_url = "https://m.vaptcha.com/api/vaptcha/validate/downtime/uwp";

        public static readonly string challenge_url = "https://m.vaptcha.com/api/vaptcha/challenge/uwp";
        public static readonly string down_challenge_url = "https://m.vaptcha.com/api/vaptcha/challenge/downtime/uwp";

        public static readonly string vaptcha_downtime = "https://m.vaptcha.com/api/vaptcha/downtime/uwpjsonp";
    }
}
