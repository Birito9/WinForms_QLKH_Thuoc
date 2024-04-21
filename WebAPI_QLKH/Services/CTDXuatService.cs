using RestSharp;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Services
{
    public class CTDXuatService
    {
        private readonly RestClient _client;

        public CTDXuatService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }

        public List<ChiTietDonXuat> LayCTDX(string id)
        {
            var request = new RestRequest($"api/ChiTietDonXuat/{id}", Method.Get);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                try
                {
                    bool isArray = response.Content.StartsWith("[") && response.Content.EndsWith("]");

                    if (isArray)
                    {
                        var ctdxList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ChiTietDonXuat>>(response.Content);

                        if (ctdxList != null && ctdxList.Any())
                        {
                            return ctdxList;
                        }
                        else
                        {
                            Console.WriteLine("API trả về một danh sách rỗng.");
                        }
                    }
                    else
                    {
                        var ctdx = Newtonsoft.Json.JsonConvert.DeserializeObject<ChiTietDonXuat>(response.Content);

                        if (ctdx != null)
                        {
                            var ctdxList = new List<ChiTietDonXuat> { ctdx };
                            return ctdxList;
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
        public RestResponse CapNhatCTDX(string id, ChiTietDonXuat payload)
        {
            var request = new RestRequest($"api/ChiTietDonXuat/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
    }
}
