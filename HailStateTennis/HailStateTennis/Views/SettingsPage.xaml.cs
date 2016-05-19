using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HailStateTennis
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        void OnChangedStaticData(object sender, ToggledEventArgs e)
        {
            App.SettingsStaticData = e.Value;
            if (App.SettingsStaticData)
            {
                UseProxy.On = false;
            }
            UseProxy.IsEnabled = !App.SettingsStaticData; // bug seems to prevent it from getting enabled/disabled
        }

        void OnChangedUseProxy(object sender, ToggledEventArgs e)
        {
            App.SettingsUseProxy = e.Value;
            // recreate the HttpClient as the proxy being used has changed
            App.HttpClientManager.Client = App.HttpClientManager.GetClient();
        }

    }
}
