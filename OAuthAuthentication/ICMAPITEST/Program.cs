using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ICMAPITEST
{
    class Program
    {

        private static HttpClient client = new HttpClient();


        internal class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }
        }



        //string baseAddress = "https://dev-439597.okta.com/oauth2/default/v1/token";           
        //string grant_type = "authorization_code";
        //string client_id = "0oa1f2cxj6rGEzOy8357";
        //string client_secret = "Client Secret received from Okta";
        //string scope = "oauth_custom_scope";
        //string userName = System.Configuration.ConfigurationManager.AppSettings.Get("userName");
        //string password = System.Configuration.ConfigurationManager.AppSettings.Get("password");
        //https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/authorize
        //Token Endpoint: https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token
        //Client Secret: Secret: ICM@2020
        //Client ID: 0deff41b-f537-3c4b-b5b9-7f61d5da8a90


        static void Main(string[] args)
        {
            //var accessTokenBasic = GetAccessTokenBasicAuthentication().Result;
            var accessTokenClientCreds = GetAccessTokenClientCredentials().Result;
            var accessToken = GetAccessToken();
            var tokenTry= GetATokenToTestMyRestApiUsingHttpClient(client);
            client = null;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://www.devtenant1.local:777/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.AccessToken);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            System.Net.ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var output = client.GetAsync("https://www.devtenant1.local:777/api/User/GetUser?userInformationGuid=9B2409CA-C718-4D24-8D02-8C9DD199CEA2&includeChildCollection=false", new HttpCompletionOption()).Result;
            var result = output.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Result: " + result);
            Console.Read();
        }


        public static async Task<Token> GetAccessTokenBasicAuthentication()
        {
            string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token";
            //string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/authorize";

            HttpClient client2 = new HttpClient();
            //var byteArray = Encoding.ASCII.GetBytes("rachit.srivastava@icertis.com:Drowssap74@");
            var byteArray = Encoding.ASCII.GetBytes("0deff41b-f537-3c4b-b5b9-7f61d5da8a90:ICM@2020");
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, token_url);
            //req.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage response = await client2.SendAsync(req);
            //HttpResponseMessage response = await client2.GetAsync(token_url);

            //HttpContent content = response.Content;
            var content = await response.Content.ReadAsStringAsync();
            // ... Read the string.
            Token tok = JsonConvert.DeserializeObject<Token>(content);
            return tok;

        }

        //OAuth2.0 Client Credentials Flow
        public static async Task<Token> GetAccessTokenClientCredentials()
        {
            string clientId = "0deff41b-f537-3c4b-b5b9-7f61d5da8a90";
            string clientSecret = "ICM@2020";
            string credentials = String.Format("{0}:{1}", clientId, clientSecret);

            using (var client1 = new HttpClient())
            {
                //Define Headers
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                //Prepare Request Body
                //List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                //requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                //FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                var form = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" }
                };

                string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token";
                //string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/authorize";

                //Request Token
                var request = await  client1.PostAsync(token_url, new FormUrlEncodedContent(form));
                var response = await request.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(response);
                return tok;
            }
        }


        private static Token GetAccessToken()
        {           
            string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token";
            string grant_type = "password";//"authorization_code";
            string client_id = "0deff41b-f537-3c4b-b5b9-7f61d5da8a90";
            string client_secret = "ICM@2020";
            string scope = "oauth_custom_scope";
            string username = "rachit.srivastava@icertis.com";
            string password = "Drowssap74@";
            string auth_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/authorize";
            //string callback_url = "https://localhost:443";
            string access_token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token";
            string code = "";
            string redirect_uri = "https://localhost:443";


            //grant_type = authorization_code
            //& code = xxxxxxxxxxx
            //& redirect_uri = https://example-app.com/redirect
            //&client_id = xxxxxxxxxx
            //& client_secret = xxxxxxxxxx

                //grant_type == "authorization_code"
                //var form = new Dictionary<string, string>
                //{
                //    {"grant_type", grant_type},
                //    //{"code", code },
                //    {"redirect_uri", redirect_uri },
                //    {"client_id", client_id},
                //    {"client_secret", client_secret}
                //    //{"scope", scope },
                //    //{"username", userName },
                //    //{"password", password }
                //};

                //(grant_type == "password")

                var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"username", username },
                    {"password", password },
                    {"client_id", client_id},
                    {"client_secret", client_secret}
                };
         

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //Exception
            //client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            try
            {
                HttpResponseMessage tokenResponse = client.PostAsync(token_url, new FormUrlEncodedContent(form)).Result;
                var jsonContent = tokenResponse.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent.Result);
                return tok;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //return string method

        //OAuth2.0 Client Authorization Flow
        private static Token GetATokenToTestMyRestApiUsingHttpClient(HttpClient client)
        {
            //var oav = GetOAuthValues(); /* object has has simple string properties for TokenUrl, GrantType, ClientId and ClientSecret */

            string token_url = "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token";
            string grant_type = "authorization_code";
            string client_id = "0deff41b-f537-3c4b-b5b9-7f61d5da8a90";
            string client_secret = "ICM@2020";
            string scope = "oauth_custom_scope";
            string userName = "rachit.srivastava@icertis.com";
            string password = "";
            string code = "";
            string redirect_uri = "https://localhost:443";


            var form = new Dictionary<string, string>
                {
                    { "grant_type", grant_type },
                    { "redirect_uri", redirect_uri },
                    { "client_id", client_id },
                    { "client_secret", client_secret }
                };

            /* now tweak the http client */
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");

            /* try 1 */
            ////client.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");

            /* try 2 */
            //ACCEPT header
            ////client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            /* try 3 */
            ////does not compile */client.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            ////application/x-www-form-urlencoded

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, token_url);
            /////req.RequestUri = new Uri(baseAddress);

            req.Content = new FormUrlEncodedContent(form);

            ////string jsonPayload = "{\"grant_type\":\"" + oav.GrantType + "\",\"client_id\":\"" + oav.ClientId + "\",\"client_secret\":\"" + oav.ClientSecret + "\"}";
            ////req.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");//CONTENT-TYPE header

            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            /* now make the request */
            ////HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            HttpResponseMessage tokenResponse = client.SendAsync(req).Result;
            Console.WriteLine(string.Format("HttpResponseMessage.ReasonPhrase='{0}'", tokenResponse.ReasonPhrase));

            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Call to get Token with HttpClient failed.");
            }

            var jsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);

            return tok;
        }


    
    }
}


//HttpResponseMessage resp;

//            using (var httpClient1 = new HttpClient())
//            {
//                var req = new HttpRequestMessage(HttpMethod.Get, "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/authorize");
////req.Headers.Add("Referer", "login.microsoftonline.com");
//req.Headers.Add("Accept", "application/x-www-form-urlencoded");
//                //req.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
//                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded; charset=UTF-8"));

//                // This is the important part:
//                req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
//                    {
//                        { "grant_type", "authorization_code" },
//                        { "client_id", "0deff41b-f537-3c4b-b5b9-7f61d5da8a90" },
//                        { "client_secret", "ICM@2020" },
//                        { "resource", "https://oauthasservices-p2001778221trial.hanatrial.ondemand.com/oauth2/api/v1/token" }
//                        //{ "username", "xxxx@xxxxx.onmicrosoft.com" },
//                        //{ "password", "xxxxxxxxxxxxx" }
//                    });

//                resp = httpClient1.SendAsync(req).Result;
//            }
