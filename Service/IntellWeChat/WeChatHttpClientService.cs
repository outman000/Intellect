using Dto.IService.IntellWeChat;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ViewModel.WeChatViewModel.ResponseModel;

namespace Dto.Service.IntellWeChat
{
    public class WeChatHttpClientService: IWeChatHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IOptions<WeChartTokenMiddles> _IOptions;
        public WeChatHttpClientService(IOptions<WeChartTokenMiddles> iOptions, IHttpClientFactory httpClientFactory)
        {
            _IOptions = iOptions;
            _httpClientFactory = httpClientFactory;
        }
        ///
        public async Task<WeChatTokenResModel> getWeChatTokenAsync()
        {
            var client = _httpClientFactory.CreateClient("WeChatToken");//必须和services.AddHttpClient()中指定的名称对应

            string content = "?grant_type=" + _IOptions.Value.grant_type + "&appid=" + _IOptions.Value.appid + "&secret=" + _IOptions.Value.secret;

            var uri = new Uri(client.BaseAddress, content);//重新组合url
            var response = client.GetAsync(uri);//调用
            var result = await response.Result.Content.ReadAsStringAsync();

            var weChartTokenMiddles = JsonConvert.DeserializeObject<WeChatTokenResModel>(result) ;
            return weChartTokenMiddles;
        }
    }
}
