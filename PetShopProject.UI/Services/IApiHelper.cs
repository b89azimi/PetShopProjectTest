using RestSharp;

namespace PetShopProject.UI.Services
{
    public interface IApiHelper
    {
        Task<RestResponse<T>> RestsharpAsync<T>(string baseUrl, string webServiceAddress, Method methodType, object body = null, bool addToken = false);
    }
}