using AuthentValitor.AuthHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AuthentValitor.Common
{
    public class WeChatAppDecrypt
    {
        private string appId = Appsettings.app(new string[] { "WeChatToken", "appid" });
        private string appSecret = Appsettings.app(new string[] { "WeChatToken", "secret" });
        private string logFile = Appsettings.app(new string[] { "WeChatToken", "LogPath" });// System.Web.HttpContext.Current.Server.MapPath("") + "\\log";
        ///// <summary>  
        ///// 构造函数  
        ///// </summary>  
        ///// <param name="appId">应用程序的AppId</param>  
        ///// <param name="appSecret">应用程序的AppSecret</param>  
        //public WeChatAppDecrypt(string appId, string appSecret)
        //{
        //    this.appId = appId;
        //    this.appSecret = appSecret;
        //    return;
        //}

        /// <summary>  
        /// 获取OpenId和SessionKey的Json数据包  
        /// </summary>  
        /// <param name="code">客户端发来的code</param>  
        /// <returns>Json数据包</returns>  
        public string GetOpenIdAndSessionKeyString(string code)
        {
            string temp = "https://api.weixin.qq.com/sns/oauth2/access_token?" +
                "appid=" + appId
                + "&secret=" + appSecret
                + "&js_code=" + code
                + "&grant_type=authorization_code";

            return GetPage(temp, "");
            //return GetUrltoHtml(temp, "post");

        }
      /// <summary>
 	  /// 通过code换取网页授权access_token地址
     /// </summary>
 	public  string Web_Access_token_URL {
         get
         {
                return string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&grant_type=authorization_code&code=", appId, appSecret);
         }
      }
        /// <summary>
        /// 获取用户的OpenId
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public  string GetOpenID(string code)
 	    {
 		         var openid = "";
                 //var openid1 = "";

                using (var wl = new WebClient())
 		        {
 			        wl.Headers.Add(HttpRequestHeader.Accept, "json");
			        wl.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=UTF-8");
			        wl.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0");
 			        wl.Encoding = Encoding.UTF8;
              
                        openid = wl.DownloadString(Web_Access_token_URL + code);
		        }
		        if (!string.IsNullOrEmpty(openid))
		        {
			        var token = JObject.Parse(openid).SelectToken("openid");
			        if (token != null)
				        openid = token.ToString();
		        }
		        return openid;
	    }
        public string GetPage(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message + ex.StackTrace;

                //创建一个文件流，用以写入或者创建一个StreamWriter  
                FileStream fs = new FileStream(logFile + "\\fileNew.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.Flush();
                // 使用StreamWriter来往文件中写入内容    
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                // 把richTextBox1中的内容写入文件    
                m_streamWriter.Write("ex.Message=" + ex.Message + "; ex.StackTrace=" + ex.StackTrace + ex.ToString());
                //这里是你的采集到的内容    
                //关闭此文件    
                m_streamWriter.Flush();
                m_streamWriter.Close();

                return string.Empty;
            }
        }

    }
}
