using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class ThuocService
    {
        private readonly RestClient _client;

        public ThuocService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<Thuoc> LayDSThuoc()
        {
            var request = new RestRequest("api/Thuoc", Method.Get);
            var response = _client.Execute<List<Thuoc>>(request);

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
        public RestResponse ThemThuoc(List<Thuoc> payloads)
        {
            var request = new RestRequest("api/Thuoc", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatThuoc(string id, Thuoc payload)
        {
            var request = new RestRequest($"api/Thuoc/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaThuoc(string id)
        {
            var request = new RestRequest($"api/Thuoc/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
