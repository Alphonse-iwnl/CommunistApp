using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace interestinG
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GetInfo();
            ImgGridView.ItemsSource = imgList;
        }
        new string Content;
        public class imginfo
        {
            public string uri { get; set; }
            public string name { get; set; }
            public string major { get; set; }
        }
        List<imginfo> imgList = new List<imginfo>();
        int temp = 2015213263;
        void GetInfo()
        {
         for (int i = 0; i < 1000; i++)
            {

                HttpClient httpClient = new HttpClient();
                string uri = $"http://hongyan.cqupt.edu.cn/cyxbsMobile/index.php/home/searchPeople/peopleList?stu={temp + i}";
                System.Net.Http.HttpResponseMessage response;
                response = httpClient.GetAsync(new Uri(uri)).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    Content = response.Content.ReadAsStringAsync().Result;

                JObject jObject = (JObject)JsonConvert.DeserializeObject(Content);
                string json = jObject["data"].ToString();
                JArray jArray = (JArray)JsonConvert.DeserializeObject(json);

                users = JsonConvert.DeserializeObject<List<userInfo>>(jArray.ToString());
                if (users.Count != 0)
                {
                    if (users[0].gender == "女        ")
                    {
                        imgList.Add(new imginfo { uri = tempimgurl + users[0].stunum, name = users[0].name, major = users[0].major });
                    }
                }
            }
        }
        string tempimgurl = "http://jwzx.cqupt.edu.cn/showstuPic.php?xh=";
        List<userInfo> users = new List<userInfo>();
        userInfo user = new userInfo();

        Image tempimg = new Image();
        private async void ImgGridView_ItemClick(object sender, ItemClickEventArgs e)
        {         
            await new MessageDialog(((imginfo)e.ClickedItem).name+" "+ ((imginfo)e.ClickedItem).major).ShowAsync();
        }
        public class userInfo
        {
            public string name { get; set; }
            public string stunum { get; set; }
            public string depart { get; set; }
            public string major { get; set; }
            public string gender { get; set; }
        }
    }
}
