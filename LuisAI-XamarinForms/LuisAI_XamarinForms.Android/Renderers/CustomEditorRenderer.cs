using System.ComponentModel;
using Android.Graphics;
using LuisAI_XamarinForms.Custom;
using LuisAI_XamarinForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace LuisAI_XamarinForms.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                nativeEditText.Background = null;

                var element = e.NewElement as CustomEditor;
                if (element != null) this.Control.Hint = element.Placeholder;

                // For Custom Fonts
                var editor = e.NewElement as CustomEditor;
                if (editor != null && !string.IsNullOrEmpty(editor.FontFamily))
                {
                    Typeface typeface = Typeface.CreateFromAsset(this.Context.Assets, editor.FontFamily);
                    Control.SetTypeface(typeface, TypefaceStyle.Normal);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomEditor.PlaceholderProperty.PropertyName)
            {
                var element = this.Element as CustomEditor;
                this.Control.Hint = element.Placeholder;
            }
        }
    }
}