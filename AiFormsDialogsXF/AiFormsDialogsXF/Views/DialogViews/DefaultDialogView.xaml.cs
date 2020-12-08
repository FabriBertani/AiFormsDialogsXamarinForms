using AiForms.Dialogs.Abstractions;
using System;

namespace AiFormsDialogsXF.Views.DialogViews
{
    public partial class DefaultDialogView : DialogView
    {
        public DefaultDialogView()
        {
            InitializeComponent();
        }

        public override void SetUp()
        {
            base.SetUp();
        }

        public override void TearDown()
        {
            base.TearDown();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void CancelAndClose_Tapped(object sender, EventArgs e)
        {
            DialogNotifier.Cancel();
        }

        private void AcceptAndClose_Tapped(object sender, EventArgs e)
        {
            DialogNotifier.Complete();
        }
    }
}