using CalcService.Core.Model;
using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CalcWin.Client.CalcService
{
    public class CalcService : ICalcService
    {
        private ICalcServiceMapper _calcServiceMapper { get; set; }
        private readonly string _url = "http://localhost:62439";
        private readonly string _method = "CalcService/Calculate";

        public CalcService(ICalcServiceMapper calcServiceMapper)
        {
            _calcServiceMapper = calcServiceMapper;
        }

        public async Task<Result> InitialAsync(CalcServiceRequest request)
        {
            var myContent = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);

            var response = client.GetAsync(_method);

            //var response = client.PostAsync(_method, byteContent).Result;

            //Result result = _calcServiceMapper.MapCalcServiceResponse(response);

            return new Result();
        }
    }
}
