using AiFormsDialogsXF.Helpers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AiFormsDialogsXF.ViewModels
{
    public class RegularDialogsViewModel : INotifyPropertyChanged
    {

        private IDialogHelper dialogHelper => DialogHelper.Instance;

        public RegularDialogsViewModel()
        {
            OpenRegularLoadingCommand = new Command(async () => await OpenRegularLoading());

            OpenFakeDownloadLoadingCommand = new Command(async () => await OpenFakeDownloadLoading());

            OpenDialogWithCustomTextCommand = new Command(async () => await OpenDialogWithCustomText());

            OpenLoadingWithCustomTextCommand = new Command(async () => await OpenLoadingWithCustomText());
        }

        private string customMessage;
        public string CustomMessage
        { 
            get => customMessage;
            set
            {
                customMessage = value;

                OnPropertyChanged(nameof(CustomMessage));
            }
        }

        public ICommand OpenRegularLoadingCommand { get; private set; }

        public ICommand OpenLoadingWithCustomTextCommand { get; private set; }

        public ICommand OpenDialogWithCustomTextCommand { get; private set; }

        public ICommand OpenFakeDownloadLoadingCommand { get; private set; }

        private async Task OpenRegularLoading()
        {
            dialogHelper.ShowLoading();

            await Task.Delay(3000);

            dialogHelper.HideLoading();
        }

        private async Task OpenLoadingWithCustomText()
        {
            dialogHelper.ShowLoading(CustomMessage);

            await Task.Delay(3000);

            dialogHelper.HideLoading();
        }

        private async Task OpenDialogWithCustomText()
        {
            var result = await dialogHelper.ShowAlert(CustomMessage, "YES", "NO");

            if (!result)
            {
                // Do something on dialog cancel
                return;
            }

            // Do something on dialog confirmation
        }

        private async Task OpenFakeDownloadLoading()
        {
            await dialogHelper.ShowLoadingWithProgressAsync(progress => ReportProgress(progress), "Downloading...");
        }

        private async Task ReportProgress(IProgress<double> progress)
        {
            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(50);

                progress.Report((i + 1) * 0.01d);
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}