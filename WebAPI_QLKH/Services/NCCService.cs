using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class NCCService
    {
        private readonly RestClient _client;

        public NCCService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<NCC> LayDS_NCC()
        {
            var request = new RestRequest("api/NCC", Method.Get);
            var response = _client.Execute<List<NCC>>(request);

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
        public RestResponse ThemNCC(List<NCC> payloads)
        {
            var request = new RestRequest("api/NCC", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatNCC(string id, NCC payload)
        {
            var request = new RestRequest($"api/NCC/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaNCC(string id)
        {
            var request = new RestRequest($"api/NCC/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
