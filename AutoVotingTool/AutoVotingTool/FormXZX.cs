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
    public partial class FormXZX : Form
    {
        public delegate void RichTextBoxCallBack(string content);
        public delegate string GetIPCallBack();
        public delegate void VotingCallBack();
        public RichTextBoxCallBack richtxtBoxCallback;
        public GetIPCallBack getIPCallBack;
        public VotingCallBack votingCallBack;
        public string Cookie = "";
        public string Ip = "";
        public string Referer = "";//;
        public string domain = "";
        public bool isStop = false;
        public int RunCount = 0;
        public string votingRefererUrl = "";
        public FormXZX()
        {
            InitializeComponent();
            domain = this.txtDomain.Text.Trim();
            GetVotingUrl();
            Referer = string.Format(@"http://{0}/" + votingRefererUrl, domain);
            richtxtBoxCallback = new RichTextBoxCallBack(WriteLog);
            getIPCallBack = new GetIPCallBack(GetIp);
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

        private void WriteLog(string content)
        {
            this.richTextBox1.Text = content + "\r\n" + this.richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunCount = 1;
            System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadFunction));
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            domain = this.txtDomain.Text.Trim();
            GetVotingUrl();
            Referer = string.Format(@"http://{0}/"+votingRefererUrl, domain);
            MessageBox.Show("域名和投票地址修改成功");
        }

        private void GetVotingUrl()
        {
            votingRefererUrl = "top/vote/top50/";
            if (comboBox1.SelectedItem.ToString().ToLower() == "top50")
            {
                votingRefererUrl = "top/vote/top50/";
            }
            else if (comboBox1.SelectedItem.ToString().ToLower() == "top20")
            {
                votingRefererUrl = "top/vote/bpotop20/";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isStop = true;
            WriteLog(string.Format(@"自动投票停止"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCode.Text.Trim(), out RunCount))
            {
                WriteLog(string.Format(@"自动投票次数不是数字"));
                return;
            }
            System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadFunction));
            th.Start();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }

        private void ThreadFunction()
        {
            MyThreadClass myThreadClassObject = new MyThreadClass(this);
            myThreadClassObject.Run();
        }


    }

    public class MyThreadClass
    {
        FormXZX myFormControl1;
        public string Ip = "";
        public MyThreadClass(FormXZX myForm)
        {
            myFormControl1 = myForm;
        }

        public void Run()
        {
            // Execute the specified delegate on the thread that owns
            // 'myFormControl1' control's underlying window handle.
            //myFormControl1.Invoke(myFormControl1.richtxtBoxCallback);
            VotingForThread();
        }
        private void VotingForThread()
        {
            int count = myFormControl1.RunCount;
            int i = 0;
            do
            {
                GetImg();
                Voting();
                i++;
                Random r = new Random();
                int rNum = r.Next(10, 15);
                myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"6、线程休眠{0},下次请求在{0}秒后执行", rNum));
                myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"------------end----------------"));
                System.Threading.Thread.Sleep(rNum * 1000);
                //WriteLog(string.Format(@"线程休眠{0},下次请求在{0}秒后执行", rNum));
                //myFormControl1.richtxtBoxCallback.Invoke(string.Format(@"线程休眠{0},下次请求在{0}秒后执行", rNum));
            } while (i < count && !myFormControl1.isStop);
        }
        /// <summary>
        /// 返回cookie
        /// </summary>
        /// <returns></returns>
        private void GetImg()
        {
            object objIp = myFormControl1.Invoke(myFormControl1.getIPCallBack);
            Ip = objIp.ToString();
            //WriteLog(string.Format(@"1、获取的随机Ip地址:{0}", Ip));
            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"1、获取的随机Ip地址:{0}", Ip));
            RequestData requestData = new RequestData();
            requestData.Headers.Add(new Header() { Key = "X-Forwarded-For", Value = Ip });
            //requestData.Headers.Add(new Header() { Key = "HTTP_CLIENT_IP", Value = "60.194.14.247" });
            requestData.Headers.Add(new Header() { Key = "Referer", Value = myFormControl1.Referer });
            requestData.Headers.Add(new Header() { Key = "X-Requested-With", Value = "XMLHttpRequest" });
            requestData.Method = RequestMethods.Post;
            requestData.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            string url = "http://" + myFormControl1.domain + "/" + myFormControl1.votingRefererUrl;
            RequestResult resultImg = HttpRequestHelper.Request(url, requestData);

            //using (System.IO.MemoryStream ms = new System.IO.MemoryStream(resultImg.ResponseStreamBytes))
            //{
            //    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);//获得验证码图片
            //    //img.Save("C:\\a.bmp");
            //    this.pictureBox1.Image = img;
            //}
            myFormControl1.Cookie = resultImg.Cookie;
            //WriteLog(string.Format(@"2、获取的Cookie:{0}", myFormControl1.Cookie));
            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"2、请求的地址:{0}", url));

            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"3、获取的Cookie:{0}", myFormControl1.Cookie));

        }

        private void Voting()
        {
            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"4、请求的地址Referer: {0}", myFormControl1.Referer));

            RequestData requestData = new RequestData();

            //requestData.Headers.Add(new Header() { Key = "HTTP_X_FORWARDED_FOR", Value = Ip });
            requestData.Headers.Add(new Header() { Key = "X-Forwarded-For", Value = Ip });
            //requestData.Headers.Add(new Header() { Key = "HTTP_CLIENT_IP", Value = "60.194.14.247" });
            requestData.Headers.Add(new Header() { Key = "Referer", Value = myFormControl1.Referer });
            requestData.Headers.Add(new Header() { Key = "X-Requested-With", Value = "XMLHttpRequest" });

            //requestData.Headers.Add(new Header() { Key = "Accept-Encoding", Value = "gzip,deflate,sdch" });
            requestData.Headers.Add(new Header() { Key = "Accept-Language", Value = "zh-CN,zh;q=0.8,en;q=0.6" });
            //requestData.Headers.Add(new Header() { Key = "Host", Value = myFormControl1.domain });
            requestData.Headers.Add(new Header() { Key = "Origin", Value = "http://" + myFormControl1.domain });
            //Content-Type:application/x-www-form-urlencoded
            //Cookie:PHPSESSID=efb22225bc31c6201f95dc470df28a5d; Hm_lvt_f24130cc0701a2a56606a07bfdb254ec=1388726592; Hm_lpvt_f24130cc0701a2a56606a07bfdb254ec=1388730397
            //Host:www.chnsourcing.com.cn
            //Origin:http://www.chnsourcing.com.cn
            //Referer:http://www.chnsourcing.com.cn/top/vote/bpotop20/
            //User-Agent:Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36
            //X-Requested-With:XMLHttpRequest 
            requestData.Method = RequestMethods.Post;
            //'t':2,'c':id,'p':1
            if (myFormControl1.votingRefererUrl.ToLower().Contains("top50"))
            {
                requestData.FormValue.Add(new FormValue() { Name = "t", Value = "2" });
            }
            else
            {
                requestData.FormValue.Add(new FormValue() { Name = "t", Value = "3" });
            }
            requestData.FormValue.Add(new FormValue() { Name = "c", Value = "139" });
            requestData.FormValue.Add(new FormValue() { Name = "p", Value = "1" });
            requestData.Accept = "application/json, text/javascript, */*";
            requestData.ContentType = "application/x-www-form-urlencoded";
            requestData.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            requestData.Cookie = myFormControl1.Cookie.Replace("; path=/","");
            string url = "http://" + myFormControl1.domain + "/app/topspoll/";
            //WriteLog(string.Format(@"3、请求的地址:{0}", url));
            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"4、请求的地址:{0}", url));

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
            // var obj = new
            // {
            //     data = new { msg = "", count = 0, status = false },
            //     info = "",
            //     status = 0
            // };

            //var objClass= JsonConvert.DeserializeAnonymousType(result.Html, obj);

            //WriteLog(string.Format(@"4、请求结果:{0}", result.Html));
            myFormControl1.Invoke(myFormControl1.richtxtBoxCallback, string.Format(@"5、请求结果:{0}", result.Html));

            //WriteLog(string.Format(@"------------end----------------"));

        }
    }

}
