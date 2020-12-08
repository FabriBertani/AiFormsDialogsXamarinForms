using AiForms.Dialogs;
using AiFormsDialogsXF.Views.DialogViews;
using System;
using System.Threading.Tasks;

namespace AiFormsDialogsXF.Helpers
{
    public class DialogHelper : IDialogHelper
    {
        private static readonly Lazy<IDialogHelper> instance = new Lazy<IDialogHelper>(() => CreateDialogHelper());

        private static IDialogHelper CreateDialogHelper() => new DialogHelper();

        public static IDialogHelper Instance => instance.Value;

        public async Task<bool> ShowAlert(string dialogText, string acceptText = "OK", string cancelText = "Cancel")
        {
            return await Dialog.Instance.ShowAsync<DefaultDialogView>(new
            {
                DialogText = dialogText,
                AcceptText = acceptText,
                CancelText = cancelText
            });
        }

        public void ShowLoading()
        {
            Loading.Instance.Show("Please wait...");
        }

        public void ShowLoading(string customMessage)
        {
            Loading.Instance.Show();

            if (!string.IsNullOrEmpty(customMessage))
                Loading.Instance.SetMessage(customMessage);
        }

        public void HideLoading()
        {
            Loading.Instance.Hide();
        }

        public async Task ShowLoadingWithProgressAsync(Func<IProgress<double>, Task> action, string customMessage)
        {
            await Loading.Instance.StartAsync(action, customMessage);
        }

        public void DisplayToast(string toastText, int duration = 3000)
        {
            Toast.Instance.Show<DefaultToastDialogView>(new
            {
                ToastText = toastText,
                Duration = duration
            });
        }
    }
}