using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaptchaSdk.UWP.Helpers;
using VaptchaSdk.UWP.Models;

namespace VaptchaSdk.UWP
{
    public class VaptchaSdk
    {
       
        public async Task<VaptchaModel> GetChallengeAsync()
        { 
            var res = await HttpHelper.GetAsync(Configs.challenge_url);
            if (res.Contains("challenge"))
            {
                var challnege = res.ToObj<ChallengeModel>();
                return new VaptchaModel
                {
                    isDown = false,
                    challenge = challnege
                };
            }
            else
            {
                var downtime = res.ToObj<DownTimeModel>();
                return new VaptchaModel
                {
                    isDown = true, 
                };
            }
           
           
        }
        public async Task<bool> ValidateAsync(string token)
        { 
            var validate = await HttpHelper.PostAsync(Configs.validate_url, token);
            Debug.WriteLine(validate);
            if (validate == "0")
            {
                return true;
            }
            return false;
        }
        public async Task<VaptchaModel> GetDownTimeChallengeAsync()
        {
            await HttpHelper.GetAsync(Configs.down_challenge_url); 
            return new VaptchaModel
            {
                isDown = true, 
            };
        }
        public async Task<bool> ValidateDownTimeAsync(string token)
        { 
            var validate = await HttpHelper.PostAsync(Configs.validate_down_url, token);
            Debug.WriteLine(validate);
            if (validate == "0")
            {
                return true;
            }
            return false;
        }
    }
}
