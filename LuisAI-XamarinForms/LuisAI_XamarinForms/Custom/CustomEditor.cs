using System;
using Xamarin.Forms;
using static Xamarin.Forms.BindableProperty;

namespace LuisAI_XamarinForms.Custom
{
    public class CustomEditor : Editor
    {
        public static readonly BindableProperty PlaceholderProperty =
            Create<CustomEditor, string>(view => view.Placeholder, String.Empty);


        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public void InvalidateLayout()
        {
            this.InvalidateMeasure();
        }
    }
}
