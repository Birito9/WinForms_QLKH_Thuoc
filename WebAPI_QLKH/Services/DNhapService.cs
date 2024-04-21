using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class DNhapService
    {
        private readonly RestClient _client;

        public DNhapService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<DonNhap> LayDSDN()
        {
            var request = new RestRequest("api/DonNhap", Method.Get);
            var response = _client.Execute<List<DonNhap>>(request);

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
        public RestResponse ThemDN(List<DonNhap> payloads)
        {
            var request = new RestRequest("api/DonNhap", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatDN(string id, DonNhap payload)
        {
            var request = new RestRequest($"api/DonNhap/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaDN(string id)
        {
            var request = new RestRequest($"api/DonNhap/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
