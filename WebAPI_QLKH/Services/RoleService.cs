using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class RoleService
    {
        private readonly RestClient _client;

        public RoleService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<Role> LayDanhSachRole()
        {
            var request = new RestRequest("api/Role", Method.Get);
            var response = _client.Execute<List<Role>>(request);

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
    }
}
