using AppFlyout.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppFlyout.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}