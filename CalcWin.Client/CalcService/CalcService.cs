using CalcWin.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using CalcWin.Client.CalcService.Mappers;
using CS = CalcWin.Client.CalcService.Model;

namespace CalcWin.Client.CalcService
{
    public class CalcService : ICalcService
    {
        private readonly ICalcServiceRequestMapper _requestMapper;
        private readonly ICalcServiceResponseMapper _responseMapper;

        private readonly string _url = "http://localhost:62439/";
        private readonly string _method = "api/CalcService/Calculate";

        public CalcService(ICalcServiceRequestMapper requestMapper, ICalcServiceResponseMapper responseMapper)
        {
            _requestMapper = requestMapper;
            _responseMapper = responseMapper;
        }

        public async Task<Result> InitialAsync(IList<Ingredient> ingredients, Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements)
        {
            var request = _requestMapper.MapCalcServiceRequest(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);
            var client = GetClient();
            var response = await client.PostAsJsonAsync(_method, request);
            var jSONResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CS.CalcServiceResponse>(jSONResponse);
            var result = _responseMapper.MapCalcServiceResponse(model);

            return result;
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "CalWin");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1));
            client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8", 1));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US", 1));

            return client;
        }
    }
}
