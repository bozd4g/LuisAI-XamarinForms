using LuisAI_XamarinForms.ViewModels;
using LuisAI_XamarinForms.Views.Custom;
using Xamarin.Forms;

namespace LuisAI_XamarinForms.DataTemplateSelector 
{
    public class MessageDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        private readonly DataTemplate _incomingDataTemplate;
        private readonly DataTemplate _outgoingDataTemplate;

        public MessageDataTemplateSelector()
        {
            this._incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this._outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is ChatDetailsBinding messageVm))
                return null;
            return messageVm.IsIncoming ? this._incomingDataTemplate : this._outgoingDataTemplate;
        }
    }
}
