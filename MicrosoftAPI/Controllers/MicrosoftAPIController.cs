

namespace MicrosoftAPI.Controllers
{
    using Microsoft.Identity.Client;

    using System;

    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;


    using System.Web;
    using RestSharp;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Net.Http;
    using System.Text;
    using System.IdentityModel.Tokens.Jwt;
    using Newtonsoft.Json.Linq;

    public class MicrosoftAPIController : ApiController
    {
        public class UserProfile
        {
            public string DisplayName { get; set; }
            public string Mail { get; set; }
            public string JobTitle { get; set; }
            //"businessPhones":[]
            public string givenName { get; set; }
            public string jobTitle { get; set; }
            public string mail { get; set; }
            public string mobilePhone { get; set; }
            public string officeLocation { get; set; }
            public string preferredLanguage { get; set; }
            public string surname { get; set; }
            public string userPrincipalName { get; set; }
            public string id { get; set; }
            public string AccessToken { get; set; }
            // Add more properties as needed
        }


        // GET: MicrosoftAPI/Details/5
        [System.Web.Mvc.HttpGet]
        public async Task<Object> GetAccessTokenAsync()
        {
            try
            {
                var TenantId = "f7f91926-db08-4315-8d88-1cbd643d8d5e";
                var clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
                var scopes = new[] { "user.read", "mail.read" }; // Example scope for Microsoft Graph API, replace with the appropriate scopes
                //var app = PublicClientApplicationBuilder.Create(clientId)
                //               .WithAuthority(AzureCloudInstance.AzurePublic, TenantId).WithRedirectUri("https://localhost:44362/")
                //               .Build();
                //var accounts = app.GetAccountsAsync();
                // Base URL with the authorization endpoint
                const string baseUrl = "https://login.microsoftonline.com/organizations/oauth2/v2.0/authorize?";

                // Replace {tenantId} with your tenant ID (e.g., UPLlimited.onmicrosoft.com)
                string url = baseUrl.Replace("{tenantId}", HttpUtility.UrlEncode(clientId.Split('-')[0])); // Assuming tenant ID is first part of client ID
                Guid guid1 = Guid.NewGuid();
                string guidString1 = guid1.ToString();
                Guid guid2 = Guid.NewGuid();
                string guidString2 = guid2.ToString();
                // Add query parameters (URL-encoded)
                url += $"&client_id={HttpUtility.UrlEncode(clientId)}";
                url += $"&scope={HttpUtility.UrlEncode(string.Join(" ", scopes))}";  // Join scopes with space
                url += $"&redirect_uri={HttpUtility.UrlEncode("https://localhost:44363/")}";
                url += $"&response_type=code";
                url += $"&state={HttpUtility.UrlEncode(guidString1)}";
                url += $"&nonce={HttpUtility.UrlEncode(guidString2)}";

                string urls = url;
                return url;




            }
            catch (Exception ex) { throw ex; }


        }

        [System.Web.Mvc.HttpGet]
        public async Task<Object> GetToken(String Code)
        {
            var TenantId = "f7f91926-db08-4315-8d88-1cbd643d8d5e";
            //var TenantId = "f66d69fd-4e80-4d76-8dd7-6ab921ddbbc7";
            var clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            ICustemWeUIs value = new ICustemWeUIs();
            string clinetSecrate1 = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";
            // string clinetSecrate2 = "f1f8a4d6-0299-47ea-afb7-d10ec710433c";
            string code = "https://localhost:44363/?Code=0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P_ZS3iAa4KZ4HzkIs9LnVtmYQB85d7OwHCCFzphItwcbw_PXBxAK9RclfX6hjVK4dIcC9kuarvftIzdNy0NrRSqSN1Y_gs2pAYBWkTj17dn_1_KlnvjEyo8SsZ0k9sXXyHfYfnOuO4vaysDycNho7ebaoD1Z5XisR8kvzP29zAV74VOhIcBTgub5-yrWvB_bC8dhlQCZ9CQVISUEXFTKQR6KNuwfvE7XTKYyRyE-dFuCD-u136InL6C_JcxNCieDVdLflPmrr_OZ04FSNRnEiWhcAyUqZjynCmykonURbmAHl3Nv5u4WgbDkPPcz-9G9Z8czQbJFmxdksD9mdIj2vwE0x9BsdrqN0DfLZ72Xqo8gN53iYn1y_SN3RK8ZcNyev3WLst_z7Pt8LxAqT1tRM96NNnZjwN3Sax1VZvIscr0MSJWZfH6yteHoYtBg9BNl_njNMYU5TYhUwZSDdWnV74CofNkSZGHOP83PBx5HfIEWkPFYr_gtZuMdErsIscA66DJxXn6_rRagZETt8Ul-65lKJD7p7BRaRPRiit7TG1xq8od8VY5CgmWUNUPV5xi5a49hJKcQJlFHMZsuX8g8bRMPUKPrcyd-UShRM0akqegCAq8uCwRtZAjbAWfJBmb9e4ZsyjAn71IurFjl_YsmXvPGo6rH0bv9KYgC3ZkUh6VfPk07Woxr2ulEYHmZwNkrqFHqWoGYJjuipi5ly5NeUnHb-hDnc1mducrKgG63oEWR_A6Y1Im1sgKYFJmfdBmgfRMxKpE&state=e4215a92-b24f-4558-ba42-7c13ee9f181e&session_state=c4e96f0a-9929-41bc-b5bc-c4d7dd84323b";
            //   var AssessToken = value.GetAccessToken(clientId, clinetSecrate1, TenantId, "https://localhost:44363/", code);
            var AssessToken = value.Main(code);

            return AssessToken;

        }




        [System.Web.Mvc.HttpGet]
        public async Task<Object> GetTokenNEw(string codes)
        {
            string tokenEndpoint = "https://login.microsoftonline.com/f7f91926-db08-4315-8d88-1cbd643d8d5e/oauth2/authorize?";
            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string clientSecret = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";
            string redirectUri = "https://localhost:44363/";
            // string code = "authorization_code";
            string[] scopes = { "user.read, mail.read" };
            string code = "0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P-gwbTQKibLuaQH73MV96Loc4pux9IBVmjSNm39F3j2g5JKPxS8LOsY5UddWtu7qOrS7n0xbpGG9HnykN3aXCBIadiEtXr8s05mWd06XYG2x-5gBEitTqcTi8Icp-WpGSjdEVwf9skcBdmDJLOYq7qSv9S2mBcq66zHXFvFF4CrG1cW1V2lLLOLibGgI9debYDXlBQwxaGTPwCERpaV4T37KWJIdHU-UeDfWqMsQ-ZTyzc4y6AO3gY3RPh1E_mEJlrvzP0iWYSHZH1IdWn7edqP0hjaDeL3LgtBoXQpSOezv7tUubPbH9JJa-55o9LNYUQfKI0QQEiz6Vbvgz66tP9DiGPjosSrS9Tq_5UZmOa9Gd3954yvGr2xUIsX67fjlc1GlYS217_UewkFk8Yj1YGRn-EzMP152AHZipeHJjBDu1g-oUmWORK1dZIgzmvvBx2diJ2HkU_Kh1EZf39BfyAC8chlkVl5E3Wh3TFGS-uA_pmHUCgcdIVIQ9ObXWMYqcN0RXwG4B9PaAX5Cnc7PItwzdNsz6uH-XfufYpnOUKCfYT5o_rRi9WIOFiGLpiHXt3BheSavlafxXI548mHdh7T0vVQhOBBR_yWENHDepriJ1da9gHixT7JP1nl-qeDInteqNMUIrp3aUN8faFADKn8Bff2W0-BVuNu7OBwU071PAgvXoQmRjB4_JYMHoYbqEKYnV_RUAtCvwn1&state=47f55e21-1b7e-4503-916b-4c3b73df6a99";
            // Construct the URL with parameters
            string url = $"{tokenEndpoint}?client_id={clientId}&client_secret={clientSecret}&redirect_uri={redirectUri}&code={code}&scope={string.Join(" ", scopes)}&grant_type=authorization_code";

            // Create a WebClient instance to perform the POST request
            using (var client = new HttpClient())
            {
                try
                {

                    // Perform the POST request asynchronously
                    var response = await client.PostAsync(url, null);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        var tokenTO = JsonConvert.DeserializeObject<TokenTO>(responseContent);

                        // Further processing with tokenTO
                        Console.WriteLine($"Response: {responseContent}");
                    }
                    else
                    {
                        // Handle non-successful response
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request exception
                    Console.WriteLine($"HTTP Request Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return null;
        }



        public class TokenTO
        {
            // Define properties corresponding to your TokenTO class in Java
        }



        [HttpPost]
        public async Task<Object> GetUserProfile(string code)
        {
            string baseUrl = $"https://login.microsoftonline.com/organizations/oauth2/v2.0/token";
            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Define the parameters to be sent in the body
                var parameters = new System.Collections.Generic.Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "client_id", "cec508e8-b896-459c-9270-63cfb6acd081" },
                { "code", code },
                { "redirect_uri", $"https://localhost:44363/" },
                { "response_mode", "query" },
                { "scope", "api://cec508e8-b896-459c-9270-63cfb6acd081/Akash" }

                // Add more parameters as needed
            };
                // Extract claims from the JWT token
                // Convert claims to JSON
                var content = new StringContent(BuildFormData(parameters), Encoding.UTF8, "application/x-www-form-urlencoded");
                // Encode the parameters as form-urlencoded
               // var content = new FormUrlEncodedContent(parameters);
                HttpCompletionOption completionOption=new HttpCompletionOption();
                // Send a POST request to the API
                HttpResponseMessage responses = await client.GetAsync(baseUrl, completionOption);
                HttpResponseMessage response = await client.PostAsync(baseUrl , content);

              

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();
                    string jsonString = responseContent;

                    // Deserialize JSON string to JObject
                    JObject jsonObject = JObject.Parse(jsonString);

                    // Extract access_token value
                    string accessTokenInstring = (string)jsonObject["access_token"];
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(accessTokenInstring);

                    // Extract payload (claims) into JSON
                    var jsonPayload = SerializeTokenPayload(token);

                    JObject jsonObjectdata = JObject.Parse(jsonPayload);
                    return jsonObjectdata;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }

        }

        static string SerializeTokenPayload(JwtSecurityToken token)
        {
            // Serialize the token's payload into JSON
            var claims = token.Claims;
            var payload = new System.Collections.Generic.Dictionary<string, string>();

            foreach (var claim in claims)
            {
                payload[claim.Type] = claim.Value;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(payload, Newtonsoft.Json.Formatting.Indented);
        }

        private string BuildFormData(Dictionary<string, string> formData)
        {
            var encodedFormData = new StringBuilder();
            foreach (var kvp in formData)
            {
                if (encodedFormData.Length > 0)
                {
                    encodedFormData.Append("&");
                }
                encodedFormData.Append($"{System.Web.HttpUtility.UrlEncode(kvp.Key)}={System.Web.HttpUtility.UrlEncode(kvp.Value)}");
            }
            return encodedFormData.ToString();
        }

        [HttpGet]
        public async Task<Object> GetAccessToken(string ct)
        {

            //var ts= ICustemWeUIs.NewToeknGet();
            //return null;
            //var client = new RestClient("https://{yourDomain}/oauth/token");
            //var request = new RestRequest(Method.Post,ct);
            //request.AddHeader("content-type", "application/x-www-form-urlaencoded");
            //request.AddParameter("application/x-www-form-urlencoded", "grant_type=authorization_code&client_id={yourClientId}&client_secret=%7ByourClientSecret%7D&code=yourAuthorizationCode%7D&redirect_uri={https://yourApp/callback}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);




            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string clientSecret = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";
            var tenantId = "f7f91926-db08-4315-8d88-1cbd643d8d5e";
            string redirectUri = "https://localhost:44363/";
            string authenticationCode = ct;

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/f7f91926-db08-4315-8d88-1cbd643d8d5e/"))
                .Build();

            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

            try
            {
                var result = await app.AcquireTokenByAuthorizationCode(scopes,authenticationCode).ExecuteAsync();
                Console.WriteLine($"Access Token: {result.AccessToken}");
            }
            catch (MsalException ex)
            {
                Console.WriteLine($"Error acquiring token: {ex.Message}");
            }

            return null;
        }



        [HttpGet]
        public async Task<object> GetAssessToken(string s)
        {
            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string clientSecret = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";
            string uri = "https://login.microsoftonline.com/organizations/oauth2/v2.0/token";
            string redirectUri = "https://localhost:44363/";
            string grantType = "authorization_code";
            string code = s;
            string scope = "api://cec508e8-b896-459c-9270-63cfb6acd081/Akash";

            string resourceUri = $"{uri}/";
            string tokenUrlEncoded = EncodedBodyForTokens(clientId, redirectUri, grantType, clientSecret, code, scope);

            HttpClient client = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("token", tokenUrlEncoded)
        });

            var response = await client.PostAsync(resourceUri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Content: {responseContent}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return null;
        }
        static string EncodedBodyForTokens(string clientId, string redirectUri, string grantType, string clientSecret, string code, string scope)
        {
            // Implement your logic to encode body for tokens
            return $"client_id={clientId}&redirect_uri={redirectUri}&grant_type={grantType}&client_secret={clientSecret}&code={code}&scope={scope}";
        }
  
        

        [HttpGet]
        public async Task<Object> Logout(string AuthenticateCode )
        {
            string baseUrl = "https://login.microsoftonline.com/UPLlimited.onmicrosoft.com/oauth2/v2.0/logout";

            // Define the query parameters
            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string idTokenHint = AuthenticateCode;
            string postLogoutRedirectUri = "https://localhost:44363/";

            // Construct the URL
            string url = $"{baseUrl}?client_id={clientId}&id_token_hint={idTokenHint}&post_logout_redirect_uri={postLogoutRedirectUri}";

            // Print the constructed URL
            return url;
        }
        }




}

