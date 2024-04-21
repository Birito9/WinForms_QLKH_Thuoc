using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.KhoController;

namespace WebAPI_QLKH.Services
{
    public class KhoService
    {
        private readonly RestClient _client;

        public KhoService(string apiBaseUrl)
        {
            _client = new RestClient(apiBaseUrl);
        }
        public List<Kho> LayDanhSachKho()
        {
            var request = new RestRequest("api/Kho", Method.Get);
            var response = _client.Execute<List<Kho>>(request);

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
        public RestResponse ThemKho(List<KhoPost> payloads)
        {
            var request = new RestRequest("api/Kho", Method.Post);
            request.AddJsonBody(payloads);
            return _client.Execute(request);
        }
        public RestResponse CapNhatKho(string id, KhoPost payload)
        {
            var request = new RestRequest($"api/Kho/{id}", Method.Put);
            request.AddJsonBody(payload);
            return _client.Execute(request);
        }
        public RestResponse XoaKho(string id)
        {
            var request = new RestRequest($"api/Kho/{id}", Method.Delete);
            var response = _client.Execute(request);
            return response;
        }
    }
}
