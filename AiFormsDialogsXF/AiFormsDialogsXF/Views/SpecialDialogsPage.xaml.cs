using AiForms.Dialogs;
using AiFormsDialogsXF.Views.DialogViews;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AiFormsDialogsXF.Views
{
    public partial class SpecialDialogsPage : ContentPage
    {
        public SpecialDialogsPage()
        {
            InitializeComponent();
        }

        private void OpenSpecialDialog_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (!await Dialog.Instance.ShowAsync<WinMoneyDialogView>())
                {
                    // Do something on dialog cancel
                    return;
                }

                // Do something on dialog confirmation
            });
        }

        private void OpenReynoldsLoading_Clicked(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var ryanReynoldsLoadingView = Loading.Instance.Create<RyanReynoldsLoadingView>();

                await ryanReynoldsLoadingView.StartAsync(async progress =>
                {
                    await Task.Delay(5000);
                });

                ryanReynoldsLoadingView.Dispose();
            });
        }

        private void OpenSpecialToast_Clicked(object sender, System.EventArgs e)
        {
            Toast.Instance.Show<WarningToastView>();
        }        
    }
}