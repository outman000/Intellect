using Dto.IService.IntellWeChat;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using System.Net.Http;
namespace Dto.Service.IntellWeChat
{
    public class WeChatHttpClientServer
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private IOptions<WeChartTokenMiddles> _IOptions;
        //public WeChatHttpClientServer(IOptions<WeChartTokenMiddles> iOptions, IHttpClientFactory httpClientFactory)
        //{
        //    _IOptions = iOptions;
        //    _httpClientFactory = httpClientFactory;
        //}
        //public void getWeChatToken()
        //{
          
            //var client = _httpClientFactory.CreateClient("WeChatToken");//必须和services.AddHttpClient()中指定的名称对应

            //string content = "?grant_type = " + _IOptions.Value.grant_type + "&appid = " + _IOptions.Value.appid + "&secret = " + _IOptions.Value.secret;
            //var uri = new Uri(client.BaseAddress, content);


            //var response = client.GetAsync(uri);
            //var weChartTokenMiddles = response.Result.Content.ReadAsStringAsync();
        //}
    }
}
