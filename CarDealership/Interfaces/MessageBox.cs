using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace CarDealership.Interfaces
{
    public static class MessageBox
    {
        public static async void Show(string content, string title)
        {
            //MessageDialog messageDialog = new MessageDialog(content, title);
            ContentDialog messageDialog = new ContentDialog();
            messageDialog.Title = title;
            messageDialog.Content = content;
            messageDialog.PrimaryButtonText = "Close";
            messageDialog.Hide();

            await messageDialog.ShowAsync();
            
            //if (messageDialog.Content != null)
            //{
            //    messageDialog.ShowAsync().Cancel();
            //    messageDialog = null;
            //}
        }
    }
}

