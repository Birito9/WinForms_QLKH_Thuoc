using RestSharp;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.KhoController;
using static WebAPI_QLKH.Controllers.TaiKhoanController;

namespace WebAPI_QLKH.Services
{
    public class TaiKhoanService
    {
        private readonly RestClient _client;

        public TaiKhoanService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<TaiKhoan> LayDSTaiKhoan()
        {
            var request = new RestRequest("api/TaiKhoan", Method.Get);
            var response = _client.Execute<List<TaiKhoan>>(request);

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
        public RestResponse ThemTaiKhoan(List<TaiKhoan> payloads)
        {
            var request = new RestRequest("api/TaiKhoan", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatTaiKhoan(string id, TaiKhoan payload)
        {
            var request = new RestRequest($"api/TaiKhoan/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaTaiKhoan(string id)
        {
            var request = new RestRequest($"api/TaiKhoan/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
