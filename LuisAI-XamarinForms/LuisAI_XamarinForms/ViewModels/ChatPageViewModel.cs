using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LuisAI_XamarinForms.Views;
using Xamarin.Forms;

namespace LuisAI_XamarinForms.ViewModels
{
    public class ChatPageViewModel : BaseModel
    {
        private bool _isRefresh;
        public bool IsRefresh
        {
            get { return _isRefresh; }
            set
            {
                _isRefresh = value;
                OnPropertyChanged(nameof(IsRefresh));
            }
        }

        private ObservableCollection<ChatBinding> _list;
        public ObservableCollection<ChatBinding> List
        {
            get
            {
                if (_list == null)
                    _list = new ObservableCollection<ChatBinding>();
                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }

        // Constructor
        public ChatPageViewModel()
        {
            BindData();

            _itemSelectedCommand = new Command(OnItemSelected);
        }

        void BindData()
        {
            List.Add(new ChatBinding
            {
                Id = 0,
                Image = ImageSource.FromFile("Chatbot.png"),
                UserId = "",
                NameSurname = "LuisBot",
                Date = DateTime.Now.ToString("d"),
                ShortMessage = "Hi! I'm your bot.."
            });
        }


        private ICommand _itemSelectedCommand;
        public ICommand ItemSelectedCommand
        {
            get { return _itemSelectedCommand; }
            set
            {
                if (_itemSelectedCommand == null)
                    return;
                _itemSelectedCommand = value;
            }
        }

        async void OnItemSelected(object e)
        {
            if (!(e is ChatBinding selectedItem))
                return;
            Application.Current.Properties["SelectedChat"] = selectedItem;
            await Application.Current.MainPage.Navigation.PushAsync(new ChatDetailsPage());
        }
    }

    public class ChatBinding
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ImageSource Image { get; set; }
        public string NameSurname { get; set; }
        public string ShortMessage { get; set; }
        public string Date { get; set; }
    }
}