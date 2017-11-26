using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LuisAI_XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatDetailsPage : ContentPage
    {
        public ChatDetailsPage()
        {
            InitializeComponent();
        }

        private void MessageEditor_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MessageEditor.InvalidateLayout();
        }
    }
}