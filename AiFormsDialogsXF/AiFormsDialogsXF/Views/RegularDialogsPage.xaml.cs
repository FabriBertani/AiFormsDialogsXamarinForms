using AiFormsDialogsXF.Helpers;
using AiFormsDialogsXF.ViewModels;
using Xamarin.Forms;

namespace AiFormsDialogsXF.Views
{
    public partial class RegularDialogsPage : ContentPage
    {
        public RegularDialogsPage()
        {
            InitializeComponent();

            BindingContext = new RegularDialogsViewModel();
        }

        private void OpenRegularToast_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DialogHelper.Instance.DisplayToast("Sample default Toast", 4500);
            });
        }
    }
}