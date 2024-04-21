using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class CTDNhapService
    {
        private readonly RestClient _client;

        public CTDNhapService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }

        public List<ChiTietDonNhap> LayCTDN(string id)
        {
            var request = new RestRequest($"api/ChiTietDonNhap/{id}", Method.Get);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                try
                {
                    bool isArray = response.Content.StartsWith("[") && response.Content.EndsWith("]");

                    if (isArray)
                    {
                        var chiTietDonNhapList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ChiTietDonNhap>>(response.Content);

                        if (chiTietDonNhapList != null && chiTietDonNhapList.Any())
                        {
                            return chiTietDonNhapList;
                        }
                        else
                        {
                            Console.WriteLine("API trả về một danh sách rỗng.");
                        }
                    }
                    else
                    {
                        var chiTietDonNhap = Newtonsoft.Json.JsonConvert.DeserializeObject<ChiTietDonNhap>(response.Content);

                        if (chiTietDonNhap != null)
                        {
                            var chiTietDonNhapList = new List<ChiTietDonNhap> { chiTietDonNhap };
                            return chiTietDonNhapList;
                        }
                        else
                        {
                            Console.WriteLine("API trả về một đối tượng đơn rỗng.");
                        }
                    }
                }
                catch (Newtonsoft.Json.JsonException ex)
                {
                    Console.WriteLine($"Lỗi khi parse dữ liệu JSON: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Lỗi khi lấy dữ liệu: {response.ErrorMessage}");
                Console.WriteLine($"Response Content: {response.Content}");
            }

            return null;
        }
        public RestResponse CapNhatCTDN(string id, ChiTietDonNhap payload)
        {
            var request = new RestRequest($"api/ChiTietDonNhap/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
    }
}
