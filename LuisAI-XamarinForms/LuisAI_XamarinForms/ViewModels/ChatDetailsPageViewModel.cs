using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LuisAI_XamarinForms.Models;
using LuisAI_XamarinForms.Provider;
using Xamarin.Forms;

namespace LuisAI_XamarinForms.ViewModels
{
    public class ChatDetailsPageViewModel : BaseModel
    {
        private ObservableCollection<ChatDetailsBinding> _list;
        public ObservableCollection<ChatDetailsBinding> List
        {
            get
            {
                if (_list == null)
                    _list = new ObservableCollection<ChatDetailsBinding>();
                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }

        private readonly ServiceManager _manager = new ServiceManager();

        public ChatDetailsPageViewModel()
        {
            BindMessages();

            _sendCommand = new Command(OnSend);
        }

        async void BindMessages()
        {
            if (!Application.Current.Properties.ContainsKey("SelectedChat"))
            {
                await Application.Current.MainPage.DisplayAlert("Hata",
                    "Hay aksi! Bir hatayla karşılaştık. Lütfen daha sonra tekrar deneyiniz.", "Tamam");
                return;
            }

            ChatBinding selectedItem = Application.Current.Properties["SelectedChat"] as ChatBinding;
            if (selectedItem?.Id == 0)
                List.Add(new ChatDetailsBinding
                {
                    Image = ImageSource.FromFile("Chatbot.png"),
                    Date = DateTime.Now.ToString("d"),
                    Text = "Hi, I'm your bot. You can ask me question for everything but sometimes I'm stupid 😁",
                    IsIncoming = true
                });
        }

        private ICommand _sendCommand;
        public ICommand SendCommand
        {
            get { return _sendCommand; }
            set
            {
                if(_sendCommand == null)
                    return;
                _sendCommand = value;
            }
        }

        async void OnSend(object e)
        {
            if(e == null)
                return;

            List.Add(new ChatDetailsBinding
            {
                Text = e.ToString(),
                IsIncoming = false,
                Date = DateTime.Now.ToString("d")
                
            });

            var result = await _manager.PostBot(
                new Luis()
                {
                    text = e.ToString(),
                    type = "message",
                    id = "8idhmm3flgbi",
                    serviceUrl = "https://c1241ef7.ngrok.io",
                    from = new From()
                    {
                        id = "default-user",
                        name = "User"
                    },
                    conversation = new Conversation()
                    {
                        id = "21dg57hma959"
                    },
                    recipient = new Recipient()
                    {
                        id = "default-user"
                    },
                    channelId = "emulator",
                    localTimestamp = DateTime.Now.ToString("o"),
                    timestamp = DateTime.Now.ToString("o"),
                    textFormat = "plain",
                    membersAdded = new List<object>(),
                    membersRemoved = new List<object>(),
                    locale = "en-US",
                    attachments = new List<object>(),
                    entities = new List<Entity>()
                    {
                        new Entity()
                        {
                            type = "ClientCapabilities",
                            requiresBotState = true,
                            supportsTts = true,
                            supportsListening = true
                        }
                    },
                    channelData = new ChannelData()
                    {
                        clientActivityId = "1511720906187.5717963883439581.0"
                    }
                });
            List.Add(new ChatDetailsBinding
            {
                Text = result,
                IsIncoming = true,
                Date = DateTime.Now.ToString("d"),
                Image = ImageSource.FromFile("Chatbot.png")

            });
        }
    }

    public class ChatDetailsBinding
    {
        public ImageSource Image { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public bool IsIncoming { get; set; }
    }
}
