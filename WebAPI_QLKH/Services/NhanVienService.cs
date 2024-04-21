using RestSharp;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.KhoController;
using static WebAPI_QLKH.Controllers.NhanVienController;

namespace WebAPI_QLKH.Services
{
    public class NhanVienService
    {
        private readonly RestClient _client;

        public NhanVienService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<NhanVien> LayDSNV()
        {
            var request = new RestRequest("api/NhanVien", Method.Get);
            var response = _client.Execute<List<NhanVien>>(request);

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
        public RestResponse ThemNV(List<NhanVien> payloads)
        {
            var request = new RestRequest("api/NhanVien", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatNV(string id, NhanVien payload)
        {
            var request = new RestRequest($"api/NhanVien/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaNV(string id)
        {
            var request = new RestRequest($"api/NhanVien/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}