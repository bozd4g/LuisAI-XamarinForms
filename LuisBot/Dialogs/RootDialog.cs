using System;
using System.Threading.Tasks;
using LuisBot.Controllers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace LuisBot.Dialogs
{
    [LuisModel("YourModelId", "SubscriptionKey")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";
            MessagesController.ResponseMessage = message;

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            string message = "Hi! I\'m your bot. You can find plate number or city name with me! You can use like \"What's plate number of 38?\"😜";
            MessagesController.ResponseMessage = message;

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("ShowPlateNumber")]
        public async Task ShowPlateNumber(IDialogContext context, LuisResult result)
        {
            City city = new City();
            string message = $"The plate number is {city.GetPlateNumberbyCity(result.Query)}. 😘";
            MessagesController.ResponseMessage = message;

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("ShowCityName")]
        public async Task ShowCityName(IDialogContext context, LuisResult result)
        {
            City city = new City();
            string message = $"The city is {city.GetCityNamebyPlateNumber(result.Query)}. 😍 😍";
            MessagesController.ResponseMessage = message;

            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    }
}