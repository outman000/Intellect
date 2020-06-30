using com.bocnet.common.security;
using System;

namespace JiaQian
{
    public class signer
    {
        public static void ceshi()
        {

            try
            {//加签
             //拼接数据  商户订单号|订单时间|订单币种|订单金额|商户号	
             //商户号：104120086510752
                String plainData = "51075220200622001|20200622112402|001|0.10|104120086510752";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(plainData);
                //     私钥证书路径、密码
                PKCS7Tool tool = PKCS7Tool.getSigner("D:\\djWork\\" + "EdayPaymentCertificate.pfx", "Eday@gh2020", "Eday@gh2020");
                String signResult = tool.sign(data);//加签
                //this.Label1.Text = signResult;
                //System.out.println(signResult);
                //*************************分割线******************************
                //本地验签，此处方法也适用于商户验银行的通知数据
                String plainData2 = "51075220200622001|20200622112402|001|0.10|104120086510752";
                //"20150427112402000001|20150427112402|001|30.00|104110059475555";//拼接数据
                byte[] data2 = System.Text.Encoding.UTF8.GetBytes(plainData2);
                PKCS7Tool tool2 = PKCS7Tool.getVerifier("D:\\djWork\\" + "sub.cer"); //公钥路
                tool2.verify(signResult, data2, null);//验签
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }
    }
}
