using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using API_Client_WinForm.ModelApi;
using System.IO;
using System.Text.Json;

namespace API_Client_WinForm
{
    public enum PeriodType
    {
        oneday=1, week=7,month=30

    }
    public class APIServes
    {
       
        
        private HttpClient client;

       private readonly string _baseUrl = "https://api.nytimes.com/svc/mostpopular/v2/";
       private readonly string _apiKey;
        public APIServes(string apiKey)
        {
            _apiKey = apiKey;
             client= new HttpClient();
        }

        protected async Task<ModelNews> GetRequest(string EndPoint)
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage
                (HttpMethod.Get, _baseUrl + EndPoint + "?api-key=" + _apiKey);
            requestMessage.Headers.Add("Accept", "application/json");
            //requestMessage.Content= new StringContent(EndPoint,Encoding.UTF8,"application/json");
            using (HttpResponseMessage responseMessage = await client.SendAsync(requestMessage))
            {
                if (responseMessage.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Error request");
                }
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(stream);
                string result=await reader.ReadToEndAsync();
                ModelNews? model = JsonSerializer.Deserialize<ModelNews>(result);

                if (model == null)
                {
                    throw new Exception("Error JSON");
                }
                return model;
                
                


            }
        }
        public async Task<ModelNews> GetArticlsLastDayAsync(PeriodType period)
        {
            int per = (int)period;
            string request = "emailed/" + per + ".json";

            return await GetRequest(request);

        }

    }
}
