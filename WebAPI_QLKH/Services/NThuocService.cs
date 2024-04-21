using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class NThuocService
    {
        private readonly RestClient _client;

        public NThuocService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<NhomThuoc> LayDSNT()
        {
            var request = new RestRequest("api/NhomThuoc", Method.Get);
            var response = _client.Execute<List<NhomThuoc>>(request);

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
        public RestResponse ThemNT(List<NhomThuoc> payloads)
        {
            var request = new RestRequest("api/NhomThuoc", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatNT(string id, NhomThuoc payload)
        {
            var request = new RestRequest($"api/NhomThuoc/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaNT(string id)
        {
            var request = new RestRequest($"api/NhomThuoc/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
