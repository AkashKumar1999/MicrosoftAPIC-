
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IdentityModel.Client;
using System.Net.Http.Headers;

namespace MicrosoftAPI.Controllers
{
    public class ICustemWeUIs
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


        public async Task<string> GetAccessToken(string clientIds, string clientSecret, string tenantId, string redirectUri, string code)
        {
            // Authority URI (replace with your tenant ID)
            var authority = "https://login.microsoftonline.com/organizations/oauth2/v2.0/token/";
            // var authority = $"https://login.microsoftonline.com/f7f91926-db08-4315-8d88-1cbd643d8d5e/v2.0";

            // Configure the MSAL client

            var scopes = new[] { "api://cec508e8-b896-459c-9270-63cfb6acd081/Akash" };
            var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(clientIds)
                .WithAuthority(authority)
                .WithClientSecret(clientSecret)
                .Build();


            var idClient = ConfidentialClientApplicationBuilder.Create(clientIds)
        .WithRedirectUri(redirectUri)
        .WithClientSecret(clientSecret)
        .Build();
            var accounts = await idClient.GetAccountsAsync();
            string message;
            string debug;

            try
            {


                var result = await idClient.AcquireTokenByAuthorizationCode(scopes, code).ExecuteAsync();

                message = "Access token retrieved.";
                debug = result.AccessToken;
            }
            catch (MsalException ex)
            {
                message = "AcquireTokenByAuthorizationCodeAsync threw an exception";
                debug = ex.Message;
            }
            // Specify the scopes (replace with your API's scopes)
            var scopess = new string[] { "api://cec508e8-b896-459c-9270-63cfb6acd081/Akash" };

            try
            {
                // Redeem the authorization code for an access token
                var tokenAcquisitionResult = await confidentialClientApplication
                    .AcquireTokenByAuthorizationCode(scopess, code)
                    .ExecuteAsync();



                return tokenAcquisitionResult.AccessToken;
            }
            catch (MsalException ex)
            {
                Console.WriteLine("Error acquiring token: {0}", ex.Message);
                throw; // Re-throw for handling in the calling code
            }
        }









        public async Task Main(string code)
        {
            // Assuming you have your token endpoint URL and necessary parameters
            var TenantId = "f7f91926-db08-4315-8d88-1cbd643d8d5e";
            //var TenantId = "f66d69fd-4e80-4d76-8dd7-6ab921ddbbc7";

            string tokenEndpoint = "https://login.microsoftonline.com/organizations/oauth2/token";
            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string clientSecret = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";
            string redirectUri = "https://localhost:44363/";
            //code = "0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P8uLHjVmN3E79gSMT2d8m8eBpTa8qNUebpRuJJSg8FXsZIWEN5--7kgqyWhcn9Hb8ETBbIQ2VPVWni0poIBthBf5SXSou_7kpLiiGZ6r9tavV6yElPOK5s0NgnG1yblXjIqwnhTwzChFpKnMdDorG7KZKjud9brIcT3mSu_W451KXGjQ5SAc9TPpQeRR_fNmRixBCjlJ_JydTOQSNYq8vWyfG97nkJymzLot6jiU1pNc6ZO7bGVQljdowhHrlSQKFhqoJIqzRqjB7wdewqEzJCcMgeCBTHhLV2IiA6_lmwMUwFEWnuXVkhXgXpSdP6yhPQ6U0voGsPTKKnDLA2rIKo0rsRl8c1kQxojQ23ndEtseIKObjn2r6YFZDbenqn_1JTc0MyH12mwvJ1WlgovLBK_qIxX5ChqvS071hgi6nI3VI63jXlmcTcVHPAmlpzow12T6jM8Qcng0SSdHxy6FW6duirHhbZNfpVOJAPrWdbj6_VLvPwsbuaLx1xGgVUxZc_eatBFk0d73dWpZoLtDzE8HKO4ltHc9ZJdiKWBtpdCqsW7ysjpDxz_hayIkKYyy0OBnroObymkRdxFcf099XwgUyQdCX2-vGQa9moyx8PoH8tZm6CCTrv0Byx7y6o5i0TvMTmPxhKnRPZjeJ634H42yGas_2qx_7AeO5h7kWZrxhOn0CBeFCRceHzqYrr3Uo7preJW0D5vpe8Nf5xJDw&state=84a09434-9057-4a9d-94f1-eda145c11796&session_state=1beb054c-52de-4560-9b9d-3510d78ee514";
            string[] scopes = { "AkashKumar" };

            var tokenUrlEncoded = new Dictionary<string, string>
        {
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "redirect_uri", redirectUri },
            { "code", code },
            { "scope", string.Join(" ", scopes) },
            { "grant_type", "authorization_code" }
        };

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(tokenUrlEncoded);
                var response = await client.PostAsync(tokenEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseEntityJson = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into your token acquisition result object
                    // For example:
                    //var tokenAcquisitionResult = JsonConvert.DeserializeObject<TokenAcquisitionResult>(responseEntityJson);

                    // Further processing with the token acquisition result
                }
                else
                {
                    Console.WriteLine($"Failed to acquire token. Status code: {response.StatusCode}");
                    // Handle error condition appropriately
                }
            }
        }







        public static async Task<RestResponse> newToken()
        {
            var client = new RestClient("https://login.microsoftonline.com/organizations/oauth2/token");
            var request = new RestRequest((Method.Post).ToString());
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=authorization_code&client_id={cec508e8-b896-459c-9270-63cfb6acd081}&client_secret=ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S&code=0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P_ZS3iAa4KZ4HzkIs9LnVtmYQB85d7OwHCCFzphItwcbw_PXBxAK9RclfX6hjVK4dIcC9kuarvftIzdNy0NrRSqSN1Y_gs2pAYBWkTj17dn_1_KlnvjEyo8SsZ0k9sXXyHfYfnOuO4vaysDycNho7ebaoD1Z5XisR8kvzP29zAV74VOhIcBTgub5-yrWvB_bC8dhlQCZ9CQVISUEXFTKQR6KNuwfvE7XTKYyRyE-dFuCD-u136InL6C_JcxNCieDVdLflPmrr_OZ04FSNRnEiWhcAyUqZjynCmykonURbmAHl3Nv5u4WgbDkPPcz-9G9Z8czQbJFmxdksD9mdIj2vwE0x9BsdrqN0DfLZ72Xqo8gN53iYn1y_SN3RK8ZcNyev3WLst_z7Pt8LxAqT1tRM96NNnZjwN3Sax1VZvIscr0MSJWZfH6yteHoYtBg9BNl_njNMYU5TYhUwZSDdWnV74CofNkSZGHOP83PBx5HfIEWkPFYr_gtZuMdErsIscA66DJxXn6_rRagZETt8Ul-65lKJD7p7BRaRPRiit7TG1xq8od8VY5CgmWUNUPV5xi5a49hJKcQJlFHMZsuX8g8bRMPUKPrcyd-UShRM0akqegCAq8uCwRtZAjbAWfJBmb9e4ZsyjAn71IurFjl_YsmXvPGo6rH0bv9KYgC3ZkUh6VfPk07Woxr2ulEYHmZwNkrqFHqWoGYJjuipi5ly5NeUnHb-hDnc1mducrKgG63oEWR_A6Y1Im1sgKYFJmfdBmgfRMxKpE&state=e4215a92-b24f-4558-ba42-7c13ee9f181e&session_state=c4e96f0a-9929-41bc-b5bc-c4d7dd84323b&redirect_uri={https://localhost:44363/}", ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            return null; ;
        }



        public async static Task<Object> NewToeknGet()
        {
            string tokenEndpoint = "https://login.microsoftonline.com/f7f91926-db08-4315-8d88-1cbd643d8d5e/oauth2/v2.0/token";

            // Client ID and secret obtained when registering your application with Azure AD
            string clientId = "cec508e8-b896-459c-9270-63cfb6acd081";
            string clientSecret = "ce~8Q~2-sVY3YiOpqvyArH1FYloyOfyhLJs2Fa5S";

            // Authorization code received from the authorization endpoint after user authentication
            string authorizationCode = "0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P8uLHjVmN3E79gSMT2d8m8eBpTa8qNUebpRuJJSg8FXsZIWEN5--7kgqyWhcn9Hb8ETBbIQ2VPVWni0poIBthBf5SXSou_7kpLiiGZ6r9tavV6yElPOK5s0NgnG1yblXjIqwnhTwzChFpKnMdDorG7KZKjud9brIcT3mSu_W451KXGjQ5SAc9TPpQeRR_fNmRixBCjlJ_JydTOQSNYq8vWyfG97nkJymzLot6jiU1pNc6ZO7bGVQljdowhHrlSQKFhqoJIqzRqjB7wdewqEzJCcMgeCBTHhLV2IiA6_lmwMUwFEWnuXVkhXgXpSdP6yhPQ6U0voGsPTKKnDLA2rIKo0rsRl8c1kQxojQ23ndEtseIKObjn2r6YFZDbenqn_1JTc0MyH12mwvJ1WlgovLBK_qIxX5ChqvS071hgi6nI3VI63jXlmcTcVHPAmlpzow12T6jM8Qcng0SSdHxy6FW6duirHhbZNfpVOJAPrWdbj6_VLvPwsbuaLx1xGgVUxZc_eatBFk0d73dWpZoLtDzE8HKO4ltHc9ZJdiKWBtpdCqsW7ysjpDxz_hayIkKYyy0OBnroObymkRdxFcf099XwgUyQdCX2-vGQa9moyx8PoH8tZm6CCTrv0Byx7y6o5i0TvMTmPxhKnRPZjeJ634H42yGas_2qx_7AeO5h7kWZrxhOn0CBeFCRceHzqYrr3Uo7preJW0D5vpe8Nf5xJDw&state=84a09434-9057-4a9d-94f1-eda145c11796&session_state=1beb054c-52de-4560-9b9d-3510d78ee514";

            // Redirect URI registered for your application
            string redirectUri = "https://localhost:4200/";

            // Resource URI for the API you want to access
            string resourceUri = "https://graph.microsoft.com/";

            // Construct the parameters required for the token request
            var tokenRequestParameters = new Dictionary<string, string>
        {
            { "grant_type", "0.ASsAJhn59wjbFUONiBy9ZD2NXugIxc6WuJxFknBjz7as0IHCAJU.AgABAAIAAADnfolhJpSnRYB1SVj-Hgd8AgDs_wUA9P8uLHjVmN3E79gSMT2d8m8eBpTa8qNUebpRuJJSg8FXsZIWEN5--7kgqyWhcn9Hb8ETBbIQ2VPVWni0poIBthBf5SXSou_7kpLiiGZ6r9tavV6yElPOK5s0NgnG1yblXjIqwnhTwzChFpKnMdDorG7KZKjud9brIcT3mSu_W451KXGjQ5SAc9TPpQeRR_fNmRixBCjlJ_JydTOQSNYq8vWyfG97nkJymzLot6jiU1pNc6ZO7bGVQljdowhHrlSQKFhqoJIqzRqjB7wdewqEzJCcMgeCBTHhLV2IiA6_lmwMUwFEWnuXVkhXgXpSdP6yhPQ6U0voGsPTKKnDLA2rIKo0rsRl8c1kQxojQ23ndEtseIKObjn2r6YFZDbenqn_1JTc0MyH12mwvJ1WlgovLBK_qIxX5ChqvS071hgi6nI3VI63jXlmcTcVHPAmlpzow12T6jM8Qcng0SSdHxy6FW6duirHhbZNfpVOJAPrWdbj6_VLvPwsbuaLx1xGgVUxZc_eatBFk0d73dWpZoLtDzE8HKO4ltHc9ZJdiKWBtpdCqsW7ysjpDxz_hayIkKYyy0OBnroObymkRdxFcf099XwgUyQdCX2-vGQa9moyx8PoH8tZm6CCTrv0Byx7y6o5i0TvMTmPxhKnRPZjeJ634H42yGas_2qx_7AeO5h7kWZrxhOn0CBeFCRceHzqYrr3Uo7preJW0D5vpe8Nf5xJDw&state=84a09434-9057-4a9d-94f1-eda145c11796&session_state=1beb054c-52de-4560-9b9d-3510d78ee514" },
            { "client_id", clientId },
            { "client_secret", clientSecret },
            { "code", authorizationCode },
            { "redirect_uri", redirectUri },
            { "resource", resourceUri } // Optional, only needed if requesting a token for a specific resource
        };

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(tokenEndpoint, new FormUrlEncodedContent(tokenRequestParameters));

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                    Console.WriteLine($"Access token: {tokenResponse.AccessToken}");
                    Console.WriteLine($"Expires in: {tokenResponse.ExpiresIn} seconds");
                    Console.WriteLine($"Token type: {tokenResponse.TokenType}");
                    Console.WriteLine($"Refresh token: {tokenResponse.RefreshToken}");
                }
                else
                {
                    Console.WriteLine($"Failed to obtain access token. Response status: {response.StatusCode}");
                    Console.WriteLine($"Response content: {responseContent}");
                }

                return null;
            }
            // var clientId = "50c4656d-8e56-44f8-92fa-a0467ef75f7a";
            //var clientId = "7d3aec47-86f9-43ff-a235-94fc6ff29861";
            //var scopes = new[] { " https://login.microsoftonline.com/f7f91926-db08-4315-8d88-1cbd643d8d5e/oauth2/v2.0/authorize?client_id=522956b1-f001-41d5-a593-48ff0e2f3018&redirect_uri=https%3A%2F%2Flocalhost%3A44370%2Fsignin-oidc&response_type=id_token&scope=openid%20profile&response_mode=form_post&nonce=638465096306769371.NTBhMDdiM2UtMGYwZi00NWExLWFmZDUtMzdiOTNiODIzZTBhNDVmMmM2ZjQtNTZkZS00NWU2LWEzZGQtZTk1MjI1MDMxODYy&client_info=1&x-client-brkrver=IDWeb.2.11.0.0&state=CfDJ8Idp_ykjeadPpdGrRRBRVLDJ77zIdZS3XCEbEKEN8zFfViCDIH-nuI8h8FN-S5GYuluDFm5uHA2OHE1NbcixPbbC0u0N0BPGmqAvTGOgjzau1V1K3RSNnBUAIM-OQyElUl_Wz4HKDR2_dR41RT9aR7NiFG6dzjarVGYhpAiGUWRwS2zY-atM3DlA3P0gJZMcWRsPDEB-EI6zWhIio6Hzw5rnzKBFUz7asNPMoU890xAy7sLVB8swygJLfO_lK0bQL3R6y9n0xJXmHW954gVSHHzJ3WwVEXlucUt2tOZOp67j&x-client-SKU=ID_NET6_0&x-client-ver=6.30.0.0" };
            var scopes = new[] { "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" };
            // var app = PublicClientApplicationBuilder.Create(TenantId)
            //                  .WithRedirectUri("https://localhost:44362/")
            //                  .Build();
            // var accounts = await app.GetAccountsAsync();
            // var result = await app.AcquireTokenInteractive(scopes)
            //                 .WithAccount(accounts.FirstOrDefault())
            //                 .WithPrompt(Prompt.SelectAccount)

            //                 .WithUseEmbeddedWebView(true)
            //                 .ExecuteAsync();



            // Using the custom web UI with AcquireTokenInteractive
            var TenantId = "6f9e78e8-708c-4468-bddf-87291f9f7abc";
            var app = PublicClientApplicationBuilder.Create(clientId)
                             .WithAuthority(AzureCloudInstance.AzurePublic, TenantId).WithRedirectUri("https://localhost:44362/")
                             .Build();
            var accounts = app.GetAccountsAsync();
            var results = await app.AcquireTokenInteractive(scopes)
                  .WithAccount((IAccount)accounts)
                  .WithPrompt(Prompt.SelectAccount)
                  // No need for WithCustomWebUi for default behavior
                  .ExecuteAsync();
            //  var result = task;
            return null;
            string accessToken = results.AccessToken;

            UserProfile values = new UserProfile();
            values.AccessToken = accessToken;



            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                //r response = client.GetAsync("https://graph.microsoft.com/v1.0/me");
                HttpResponseMessage response = await client.GetAsync("https://graph.microsoft.com/v1.0/me");
                if (response.IsSuccessStatusCode)
                {
                    var userProfileJson = response.Content.ReadAsStringAsync();
                    var userProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<UserProfile>(userProfileJson.Result);
                    //  return userProfile.surname.ToString();
                }
                else
                {
                    throw new Exception($"Failed to retrieve user profile. Status code: {response.StatusCode}");
                }
            }





        }


    }

}