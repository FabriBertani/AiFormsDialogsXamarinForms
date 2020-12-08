using AiForms.Dialogs.Abstractions;
using Xamarin.Forms;

namespace AiFormsDialogsXF.Views.DialogViews
{
    public partial class RyanReynoldsLoadingView : LoadingView
    {
        private Animation animation;

        public RyanReynoldsLoadingView()
        {
            InitializeComponent();

            this.animation = new Animation
            {
                { 0, 0.5, new Animation (v => ryanReynoldsFace.Scale = v, 1, 2) },
                { 0, 1, new Animation (v => ryanReynoldsFace.Rotation = v, 0, 360) },
                { 0.5, 1, new Animation (v => ryanReynoldsFace.Scale = v, 2, 1) }
            };
        }

        public override void RunPresentationAnimation()
        {
            this.Animate("ryanReynoldsAnimation", animation, 16, 1500, null, (v, c) =>
            {
                ryanReynoldsFace.Scale = 1;
                ryanReynoldsFace.Rotation = 0;
            },
            repeat: () => true);
        }

        public override void RunDismissalAnimation()
        {
            this.AbortAnimation("ryanReynoldsAnimation");
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}