using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Web;

namespace DMedia.FetionActivity.Module.Utils
{
    public class HttpRequestHelper
    {
        public const string CONTENT_BOUNDARY = "----------ae0cH2cH2GI3Ef1KM7GI3Ij5cH2gL6";
        public const string CONTENT_BOUNDARY_PREFIX = "--";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static RequestResult Request(string url)
        {
            return Request(url, new RequestData());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static RequestResult Request(string url, RequestData requestData)
        {
            MemoryStream postStream = null;
            BinaryWriter postWriter = null;
            HttpWebResponse response = null;
            StreamReader responseStreamReader = null;
            Stream requestStream = null;
            Stream responseStream = null;
            //创建内存流
            MemoryStream responseMemoryStream = null;
            Encoding requestEncoding = Encoding.UTF8;
            Encoding responseEncoding = Encoding.UTF8;

            if (requestData == null)
            {
                return null;
            }

            requestEncoding = requestData.RequestEncoding;
            responseEncoding = requestData.ResponseEncoding;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (request == null)
                {
                    return null;
                }

                //UserAgent
                request.UserAgent = requestData.UserAgent;

                //ContentType
                if (requestData.ContentType == "multipart/form-data;")
                {
                    request.ContentType = "multipart/form-data; boundary=" + CONTENT_BOUNDARY;
                }
                else
                {
                    request.ContentType = requestData.ContentType;
                }

                //UserAgent
                request.Accept = requestData.Accept;

                //Connection
                request.KeepAlive = requestData.KeepAlive;

                //设置代理
                if (requestData.WebProxy != null)
                {
                    // request.UseDefaultCredentials = true;
                    request.Proxy = requestData.WebProxy;
                }

                //设置过期时间
                request.Timeout = 300000;
                if (request.Timeout > 0)
                {
                    request.Timeout = requestData.Timeout;
                }


                //请求类型
                if (requestData.Method == RequestMethods.Get)
                {
                    request.Method = "Get";
                }
                else
                {
                    request.Method = "POST";
                }

                //初始化头部信息
                InitHeaders(request, requestData);

                //添加Cookie
                if (!string.IsNullOrEmpty(requestData.Cookie))
                {
                    CookieContainer co = new CookieContainer();
                    co.SetCookies(new Uri(url), requestData.Cookie);
                    request.CookieContainer = co;
                }
                //写表单数据
                postStream = new MemoryStream();
                postWriter = new BinaryWriter(postStream);
                if (requestData.FormValue != null && requestData.FormValue.Count > 0)
                {
                    if (requestData.ContentType == "multipart/form-data;")
                    {
                        WriteMultipartFormData(postWriter, requestData.FormValue, requestEncoding);
                    }
                    else
                    {
                        WriteFormData(postWriter, requestData.FormValue, requestEncoding);
                    }
                }
                request.ContentLength = postStream.Length;

                requestStream = request.GetRequestStream();
                postStream.WriteTo(requestStream);
                response = (HttpWebResponse)request.GetResponse();

                responseStream = response.GetResponseStream();
                byte[] bArr = ReadFully(responseStream);
                responseMemoryStream = new MemoryStream(bArr);
                responseStreamReader = new StreamReader(responseMemoryStream, responseEncoding);

                RequestResult result = new RequestResult();

                result.Html = responseStreamReader.ReadToEnd();
                result.ResponseStreamBytes = bArr;
                result.StatusCode = (int)response.StatusCode;
                result.Cookie = response.Headers.Get("Set-Cookie");

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    Header header = new Header();
                    header.Key = response.Headers.Keys[i];
                    header.Value = response.Headers[i];
                    result.Headers.Add(header);
                }

                return result;
            }
            catch (Exception ex)
            {
                
                RequestResult result = new RequestResult();

                result.StatusCode = -1;
                result.Html = ex.Message;

                return result;
            }
            finally
            {
                if (postWriter != null)
                {
                    postWriter.Close();
                }

                if (postStream != null)
                {
                    postStream.Close();
                    postStream.Dispose();
                }

                if (response != null)
                {
                    response.Close();
                }

                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
                if (responseStreamReader != null)
                {
                    responseStreamReader.Close();
                    responseStreamReader.Dispose();
                }
                if (requestStream != null)
                {
                    requestStream.Close();
                    requestStream.Dispose();
                }
                if (responseMemoryStream != null)
                {
                    responseMemoryStream.Close();
                    responseMemoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postWriter"></param>
        /// <param name="formValues"></param>
        /// <param name="requestEncoding"></param>
        private static void WriteFormData(BinaryWriter postWriter, List<FormValue> formValues, Encoding requestEncoding)
        {
            string temp = "";

            temp = EncodeValue(formValues[0].Name, formValues[0].Value, requestEncoding);
            for (int i = 1; i < formValues.Count; i++)
            {
                temp += "&" + EncodeValue(formValues[i].Name, formValues[i].Value, requestEncoding);
            }

            postWriter.Write(GetBytes(requestEncoding, temp));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postWriter"></param>
        /// <param name="formValues"></param>
        /// <param name="requestEncoding"></param>
        private static void WriteMultipartFormData(BinaryWriter postWriter, List<FormValue> formValues, Encoding requestEncoding)
        {
            foreach (FormValue formValue in formValues)
            {
                if (formValue.BinaryData != null && formValue.BinaryData.Length > 0)
                {
                    postWriter.Write(GetBytes(requestEncoding, CONTENT_BOUNDARY_PREFIX, CONTENT_BOUNDARY, "\r\n", string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\";\r\n\r\n", formValue.Name, formValue.Value)));
                    postWriter.Write(formValue.BinaryData);
                    postWriter.Write(GetBytes(requestEncoding, "\r\n"));
                }
                else
                {
                    postWriter.Write(GetBytes(requestEncoding, CONTENT_BOUNDARY_PREFIX, CONTENT_BOUNDARY, "\r\n", string.Format("Content-Disposition: form-data; name=\"{0}\";\r\n\r\n", formValue.Name)));
                    postWriter.Write(GetBytes(requestEncoding, formValue.Value));
                    postWriter.Write(GetBytes(requestEncoding, "\r\n"));
                }
            }

            postWriter.Write(GetBytes(requestEncoding, CONTENT_BOUNDARY_PREFIX, CONTENT_BOUNDARY, "--"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string EncodeValue(string name, string value, Encoding encodeEncoding)
        {
            return string.Format("{0}={1}", HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestData"></param>
        private static void InitHeaders(HttpWebRequest request, RequestData requestData)
        {
            if (requestData != null && requestData.Headers != null && requestData.Headers.Count > 0)
            {
                foreach (Header header in requestData.Headers)
                {
                    InitHeaders(request, header.Key, header.Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void InitHeaders(HttpWebRequest request, string key, string value)
        {
            if (String.Compare(key, "Accept", true) == 0)
            {
                request.Accept = value;
            }
            else if (String.Compare(key, "User-Agent", true) == 0)
            {
                request.UserAgent = value;
            }
            else if (String.Compare(key, "Referer", true) == 0)
            {
                request.Referer = value;
            }
            else
            {
                request.Headers[key] = value;
            }
        }

        /// <summary>
        /// 返回UTF8编码
        /// </summary>
        /// <param name="encoding">返回编码值</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        private static byte[] GetBytes(Encoding encoding, params string[] content)
        {
            string temp = "";
            for (int i = 0; i < content.Length; i++)
            {
                temp += content[i];
            }
            return encoding.GetBytes(temp);
        }

        private static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[128];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
    }
}
