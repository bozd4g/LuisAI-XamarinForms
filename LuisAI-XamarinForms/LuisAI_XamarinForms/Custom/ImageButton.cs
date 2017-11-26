using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LuisAI_XamarinForms.Custom
{
    public class ImageButton : Image
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create<ImageButton, ICommand>(p => p.Command, null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create<ImageButton, object>(p => p.CommandParameter, null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.AnchorX = 0.48;
                    this.AnchorY = 0.48;
                    await this.ScaleTo(0.8, 50, Easing.Linear);
                    await Task.Delay(100);
                    await this.ScaleTo(1, 50, Easing.Linear);
                    Command?.Execute(CommandParameter);
                });
            }
        }

        public ImageButton()
        {
            Initialize();
        }


        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TransitionCommand
            });
        }
    }
}
