using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_QLKH.Controllers;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.LoController;

namespace WebAPI_QLKH.Services
{
    public class LoService
    {
        private readonly RestClient _restClient;

        public LoService(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public List<Lo> LayDSLo()
        {
            var request = new RestRequest("api/Lo", Method.Get);
            var response = _restClient.Execute<List<Lo>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                Console.WriteLine($"Lỗi khi lấy dữ liệu: {response.ErrorMessage}");
                return null;
            }
        }
        public async Task<RestResponse> ThemLo(LoPost loPost)
        {
            var request = new RestRequest("api/Lo", Method.Post)
                .AddJsonBody(loPost);

            return await _restClient.ExecuteAsync(request);
        }
        public RestResponse CapNhatLo(string id, Lo payload)
        {
            var request = new RestRequest($"api/Lo/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _restClient.Execute(request);
        }
        public RestResponse XoaLo(string id)
        {
            var request = new RestRequest($"api/Lo/{id}", Method.Delete);
            var response = _restClient.Execute(request);
            return response;
        }
    }
}
