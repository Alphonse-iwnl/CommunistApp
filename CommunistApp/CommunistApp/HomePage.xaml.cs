using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CommunistApp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        List<Item> sixItem = new List<Item>()
        {
            new Item {ItemName="党章党规" },
            new Item {ItemName="系列讲话" },
            new Item {ItemName="合格党员" },
            new Item {ItemName="网络活动" },
            new Item {ItemName="先进典范" },
            new Item {ItemName="经典影像" }
        };
        public HomePage()
        {
            this.InitializeComponent();
            SixItem.ItemsSource = sixItem;
        }

        private void SixItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        public class Item
        {
            public string ItemName { get; set; }
        }
    }
}

