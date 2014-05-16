using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DMedia.FetionActivity.Module.Utils;
using Newtonsoft.Json;
//using MODI;
namespace AutoVotingTool
{
    public partial class Form1 : Form
    {
        public string Cookie = "";
        public string Ip = "";
        public string Referer = "";//"http://tp.jzyouth.net/Html/114.html";
        public string domain = "";
        public Form1()
        {
            InitializeComponent();
            domain = this.txtDomain.Text.Trim();
            Referer = string.Format(@"http://{0}/Html/114.html",domain);
        }

        /// <summary>
        /// 返回cookie
        /// </summary>
        /// <returns></returns>
        private void GetImg()
        {
            Ip = GetIp();
            WriteLog(string.Format(@"1、获取的随机Ip地址:{0}", Ip));
            RequestData requestData = new RequestData();
            requestData.Headers.Add(new Header() { Key = "X-Forwarded-For", Value = Ip });
            //requestData.Headers.Add(new Header() { Key = "HTTP_CLIENT_IP", Value = "60.194.14.247" });
            requestData.Headers.Add(new Header() { Key = "Referer", Value = Referer });
            requestData.Headers.Add(new Header() { Key = "X-Requested-With", Value = "XMLHttpRequest" });
            requestData.Method = RequestMethods.Post;
            requestData.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            RequestResult resultImg = HttpRequestHelper.Request("http://" + domain + "/Index/verify/time/" + DateTime.Now.ToString("HHss"), requestData);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(resultImg.ResponseStreamBytes))
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);//获得验证码图片
                //img.Save("C:\\a.bmp");
                this.pictureBox1.Image = img;
            }
            Cookie = resultImg.Cookie;
            WriteLog(string.Format(@"2、获取的Cookie:{0}",Cookie));
        }

        private string GetIp()
        {

            int ip1_1 = Convert.ToInt32(txtIp1_1.Text.Trim());
            ip1_1 = (ip1_1 < 0 || ip1_1 > 254) ? 210 : ip1_1;
            int ip1_2 = Convert.ToInt32(txtIp1_2.Text.Trim());
            ip1_2 = (ip1_2 < 0 || ip1_2 > 254) ? 047 : ip1_2;
            int ip1_3 = Convert.ToInt32(txtIp1_3.Text.Trim());
            ip1_3 = (ip1_3 < 0 || ip1_3 > 254) ? 176 : ip1_3;
            int ip1_4 = Convert.ToInt32(txtIp1_4.Text.Trim());
            ip1_4 = (ip1_4 < 0 || ip1_4 > 254) ? 1 : ip1_4;


            int ip2_1 = Convert.ToInt32(txtIp2_1.Text.Trim());
            ip2_1 = (ip2_1 < 0 || ip2_1 > 254) ? 210 : ip2_1;
            int ip2_2 = Convert.ToInt32(txtIp2_2.Text.Trim());
            ip2_2 = (ip2_2 < 0 || ip2_2 > 254) ? 047 : ip2_2;
            int ip2_3 = Convert.ToInt32(txtIp2_3.Text.Trim());
            ip2_3 = (ip2_3 < 0 || ip2_3 > 254) ? 191 : ip2_3;
            int ip2_4 = Convert.ToInt32(txtIp2_4.Text.Trim());
            ip2_4 = (ip2_4 < 0 || ip2_4 > 254) ? 255 : ip2_4;
            


            //210.047.176.000~210.047.191.255 锦州
            string ip1 = new System.Random().Next(ip1_1, ip2_1).ToString();
            System.Threading.Thread.Sleep(200);
            string ip2 = new System.Random().Next(ip1_2, ip2_2).ToString();
            System.Threading.Thread.Sleep(200);
            string ip3 = new System.Random().Next(ip1_3, ip2_3).ToString();
            System.Threading.Thread.Sleep(200);
            string ip4 = new System.Random().Next(ip1_4, ip2_4).ToString();

            string ip = ip1 + '.' + ip2 + '.' + ip3 + '.' + ip4;
            return ip;
        }

        private void btnRefreshImg_Click(object sender, EventArgs e)
        {
            GetImg();
        }
        private void WriteLog(string content)
        {
            this.richTextBox1.Text = content + "\r\n" + this.richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestData requestData = new RequestData();
            requestData.Headers.Add(new Header() { Key = "X-Forwarded-For", Value = Ip });
            //requestData.Headers.Add(new Header() { Key = "HTTP_CLIENT_IP", Value = "60.194.14.247" });
            requestData.Headers.Add(new Header() { Key = "Referer", Value = Referer });
            requestData.Headers.Add(new Header() { Key = "X-Requested-With", Value = "XMLHttpRequest" });
            requestData.Method = RequestMethods.Post;
            //requestData.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requestData.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            requestData.Cookie = Cookie;
            string url = "http://" + domain + "/Index/vote/id/114/verify/" + this.txtCode.Text.Trim();
            WriteLog(string.Format(@"3、请求的地址:{0}", url));
            RequestResult result = HttpRequestHelper.Request(url, requestData);
            //            {
            //    "data": {
            //        "msg": "投票成功，投票数据正在统计中",
            //        "count": 0,
            //        "status": true
            //    },
            //    "info": "",
            //    "status": 1
            //}
            var obj = new
            {
                data = new { msg = "", count = 0, status = false },
                info = "",
                status = 0
            };

           var objClass= JsonConvert.DeserializeAnonymousType(result.Html, obj);

           WriteLog(string.Format(@"4、请求结果:{0}", objClass.data.msg));
           WriteLog(string.Format(@"------------end----------------"));
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var url1 = "/Index/getvote/id/" + $("#id").val();
            RequestData requestData = new RequestData();
            requestData.Headers.Add(new Header() { Key = "X-Forwarded-For", Value = Ip });
            //requestData.Headers.Add(new Header() { Key = "HTTP_CLIENT_IP", Value = "60.194.14.247" });
            requestData.Headers.Add(new Header() { Key = "Referer", Value = Referer });
            requestData.Headers.Add(new Header() { Key = "X-Requested-With", Value = "XMLHttpRequest" });
            requestData.Method = RequestMethods.Post;
            //requestData.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requestData.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            string url = "http://" + domain + "/Index/getvote/id/114";
            RequestResult result = HttpRequestHelper.Request(url, requestData);
            //{"data":{"count":"1766"},"info":"","status":1}
            var obj = new
            {
                data = new {  count = 0 },
                info = "",
                status = 0
            };

            var objClass = JsonConvert.DeserializeAnonymousType(result.Html, obj);
            this.lblCount.Text = objClass.data.count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            domain = this.txtDomain.Text.Trim();
            Referer = string.Format(@"http://{0}/Html/114.html", domain);
            MessageBox.Show("域名修改成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormXZX f = new FormXZX();
            f.ShowDialog();
        }
    }
}
