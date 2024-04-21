using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.ChiNhanhController;

namespace FormQLKH.Services
{
    public class ChiNhanhService
    {
        private readonly RestClient _client;

        public ChiNhanhService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<ChiNhanh> LayDanhSachChiNhanh()
        {
            var request = new RestRequest("api/ChiNhanh", Method.Get);
            var response = _client.Execute<List<ChiNhanh>>(request);

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
        public RestResponse ThemChiNhanh(List<ChiNhanhPost> payloads)
        {
            var request = new RestRequest("api/ChiNhanh", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatChiNhanh(string id, ChiNhanhPost payload)
        {
            var request = new RestRequest($"api/ChiNhanh/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaChiNhanh(string id)
        {
            var request = new RestRequest($"api/ChiNhanh/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
