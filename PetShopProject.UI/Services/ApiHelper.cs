using Newtonsoft.Json;
using RestSharp;

namespace PetShopProject.UI.Services
{
    public class ApiHelper : IApiHelper
    {
        public virtual async Task<RestResponse<T>> RestsharpAsync<T>(
            string baseUrl,
            string webServiceAddress,
            Method methodType,
            object body = null,
            bool addToken = false
            )
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentException("baseUrl cannot be null or empty", nameof(baseUrl));

            if (string.IsNullOrEmpty(webServiceAddress))
                throw new ArgumentException("webServiceAddress cannot be null or empty", nameof(webServiceAddress));


            var options = new RestClientOptions(baseUrl)
            {

                // MaxTimeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest(webServiceAddress, methodType);
            request.AddHeader("Content-Type", "application/json");

            if (body != null)
                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

            var response = await client.ExecuteAsync<T>(request);
            return response;
        }

    }

}