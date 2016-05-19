using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace HailStateTennis
{
    public class HttpClientManager
    {
        public HttpClient Client { get; set; }
        public HttpClientManager()
        {
            Client = GetClient();
        }
        public HttpClient GetClient()
        {
            HttpClient client;

            if (App.SettingsUseProxy)
            {
                //var authData = string.Format ("{0}:{1}", Constants.Username, Constants.Password);
                //var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));

                // method below comes from combination of
                //    stackoverflow.com/questions/29856543/httpclient-and-using-proxy-constantly-getting-407
                //    social.msdn.microsoft.com/Forums/vstudio/en-US/c06d3032-dceb-4a1a-bb6a-778fd13a938a/407-proxy-authentication-required
                Uri proxyUri = new Uri(String.Format("{0}:{1}", Constants.ProxyServer, Constants.ProxyPort));
                NetworkCredential proxyCreds = new NetworkCredential(Constants.ProxyUser, Constants.ProxyPassword);
                WebProxy proxy = new WebProxy(proxyUri)
                {
                    Credentials = proxyCreds
                    //Credentials = (NetworkCredential)CredentialCache.DefaultCredentials
                };
                HttpClientHandler handler = new HttpClientHandler()
                {
                    Proxy = proxy,
                    PreAuthenticate = true,
                    UseDefaultCredentials = false
                };
                // below line used only if the server you are connecting to requires a username and password
                //handler.Credentials = new NetworkCredential("serveruid", "serverpwd");
                client = new HttpClient(handler);
                //client.MaxResponseContentBufferSize = 256000;
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);
            }
            else
            {
                client = new HttpClient();
            }
            return client;
        }
    }
}
