using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class DXuatService
    {
        private readonly RestClient _client;

        public DXuatService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<DonXuat> LayDSDX()
        {
            var request = new RestRequest("api/DonXuat", Method.Get);
            var response = _client.Execute<List<DonXuat>>(request);

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
        public RestResponse ThemDX(List<DonXuat> payloads)
        {
            var request = new RestRequest("api/DonXuat", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatDX(string id, DonXuat payload)
        {
            var request = new RestRequest($"api/DonXuat/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaDX(string id)
        {
            var request = new RestRequest($"api/DonXuat/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
