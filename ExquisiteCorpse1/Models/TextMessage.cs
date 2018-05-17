using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ExquisiteCorpse1.Data;

namespace ExquisiteCorpse1.Models
{
    public class TextMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        public TextMessage( )
        {
            From = "+15416251981";
        }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EV.AccountSid + "/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator(EV.AccountSid, EV.AuthToken);
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
        }


        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }

}

