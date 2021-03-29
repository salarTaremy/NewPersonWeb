using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewPersonWeb.Farapayamak
{
    public class SMS
    {
        string ActiveLine;
        string username = "9123712702";
        string password = "iranbath1";
        public SMS()
        {
            this.ActiveLine = "10002166422655";
            //this.ActiveLine = "30001220240910";
        }
        public SMS(string LineNumber)
        {
            this.ActiveLine = LineNumber;
        }
        public SMSResult SendMessage(string Mobile, string Message)
        {
            try
            {
                string Url = "https://rest.payamak-panel.com/api/SendSMS/SendSMS";
                string myParameters = $"username={username}&password={password}&to={Mobile}&from={this.ActiveLine}&text={Message}";
                SMSResult result;
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(Url, myParameters);
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<SMSResult>(HtmlResult);
                }
                return result;
            }
            catch (Exception )
            {

                throw ;
            }
        }
        public Task<SMSResult> SendMessageAsync(string Mobile, string Message)
        {
            try
            {
                return Task.Run(() =>
                {

                    //Thread.Sleep(15000);
                    string Url = "https://rest.payamak-panel.com/api/SendSMS/SendSMS";
                    string myParameters = $"username={username}&password={password}&to={Mobile}&from={this.ActiveLine}&text={Message}";
                    SMSResult result;
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        string HtmlResult = wc.UploadString(Url, myParameters);
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<SMSResult>(HtmlResult);
                    }
                    return result;
                }
                    );
            }
            catch (Exception )
            {

                throw ;
            }
        }

        public SMSLine GetListOfLines
        {
            get
            {
                try
                {
                    string Url = "https://rest.payamak-panel.com/api/SendSMS/GetUserNumbers";
                    string myParameters = $"username={username}&password={password}";
                    SMSLine result;
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        string HtmlResult = wc.UploadString(Url, myParameters);
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<SMSLine>(HtmlResult);
                    }
                    return result;
                }
                catch (Exception )
                {

                    throw ;
                }
            }
        }
    }
}
