using CalcService.Core.Model;
using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CalcWin.Client.CalcService
{
    public class CalcService : ICalcService
    {
        private static readonly HttpClient _client = new HttpClient();

        private ICalcServiceMapper _calcServiceMapper { get; set; }
        private readonly string _url = "http://localhost:62439/";
        private readonly string _method = "api/CalcService/Calculate";

        public CalcService(ICalcServiceMapper calcServiceMapper)
        {
            _calcServiceMapper = calcServiceMapper;
            _client.BaseAddress = new Uri(_url);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "CalWin");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1));
            _client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8", 1));
            _client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US", 1));
        }

        public async Task<Result> InitialAsync(CalcServiceRequest request)
        {
            var req = new TestModel
            {
                Name = "Edek",
                Ilosc = "13"
            };

            // sposób 1
            //var json = JsonConvert.SerializeObject(req);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Sposób 2
            var response = await _client.PostAsJsonAsync<TestModel>("api/CalcService/Test", req);

            // Odczyt odpowiedzi
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<TestModel>(json);

            //Result result = _calcServiceMapper.MapCalcServiceResponse(response);

            return new Result();
        }
    }
}
