using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RssFeed
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            string s = @"zdfgdasfgfdg#TPSTART#
#T#Appzillon#E#
#H#Appzillon IDE#E#
#D#Appzillon is a product#E#
#S#Part of I-exceed company#E#
#IURL#http://i-exceed.com/wp-content/uploads/2015/10/iexceed-logo_light.png#E#
#NAV#http://i-exceed.com/#E#
#NEXT#
#T#Syd Bank#E#
#H#App created for Syd Bank#E#
#D#Powered by appzillon#E#
#S#Work in Progress App#E#
#IURL#http://i-exceed.com/wp-content/uploads/2016/03/syndicate-bank-logo1.png#E#
#NAV#http://i-exceed.com/#E#
#NEXT#
#T#Quote#E#
#H#Inspiration#E#
#D#Inspirational Quotes#E#
#S#Live Life Long#E#
#NEXT#
#TPEND#dfgsdfgs";
            listView.ItemsSource = new TPLib().GetTPData(s);
        }

        private async void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string a = e.ClickedItem.ToString();
            await Windows.System.Launcher.LaunchUriAsync(new Uri((e.ClickedItem as TPObject).Nav));
            Debug.WriteLine(a);
        }
    }
}
