using Apsis.Shared.DTO;
using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Service.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Services.ApiCreditCardService
{
    public class CreditCardService : ICreditCardService
    {
        private readonly HttpClient _httpClient;

        public CreditCardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IDataResult<CreditCardDto>> WithdrawMoney(CreditCardDto cardDto)
        {
            string json = JsonSerializer.Serialize(cardDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var uri = new Uri($"{_httpClient.BaseAddress}creditcard/withdrawmoney");

            var response = await _httpClient.PostAsync(uri, content);

            //var response = await _httpClient.GetAsync("creditcard/withdrawmoney");

            if (!response.IsSuccessStatusCode)
            {
                return new ErrorDataResult<CreditCardDto>();
            }

            var responseSuccess = response.Content.ReadFromJsonAsync<Response<CreditCardDto>>();

            return new SuccessDataResult<CreditCardDto>();
        }
    }
}
