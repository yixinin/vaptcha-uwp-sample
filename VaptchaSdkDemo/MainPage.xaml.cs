using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VaptchaSdk.UWP.Helpers;
using VaptchaSdk.UWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace VaptchaSdkDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        VaptchaSdk.UWP.VaptchaSdk vaptcha;
        public MainPage()
        {
            this.InitializeComponent();
            vaptcha_web.ScriptNotify += vaptcha_web_ScriptNotify;
            vaptcha = new VaptchaSdk.UWP.VaptchaSdk();
        }

        private async void click_Click(object sender, RoutedEventArgs e)
        {

            var data = await vaptcha.GetChallengeAsync();
            if (!data.isDown)
            {
                var text = $"vid:{data.challenge.id}, challenge:{data.challenge.challenge}";
                debug.Text = text;
                Debug.WriteLine(text);
                if (data != null && !string.IsNullOrWhiteSpace(data.challenge.challenge))
                    ShowVaptcha(data.challenge.id, data.challenge.challenge);
            }
            else
            {
                ShowDown();
            }

        }

        public void ShowVaptcha(string id, string challenge)
        {
            vaptcha_web.Visibility = Visibility.Visible;
            vaptcha_web.Navigate(new Uri($"{VaptchaSdk.UWP.Configs.vaptcha_url}?vid={id}&ai={false}&lang=zh_CN&challenge={challenge}&outage={VaptchaSdk.UWP.Configs.vaptcha_downtime}"));
        }

        public void ShowDown()
        {
            vaptcha_web.Visibility = Visibility.Visible;
            vaptcha_web.Navigate(new Uri($"{VaptchaSdk.UWP.Configs.vaptcha_url}?outage={VaptchaSdk.UWP.Configs.vaptcha_downtime}"));
        }

        private async void vaptcha_web_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var json = e.Value; 
            if (json.Contains("token"))
            {
                var res = await vaptcha.ValidateAsync(json);
                if (res)
                    debug.Text = "pass";
                else debug.Text = "fail";

            } 
        }
    }
}
