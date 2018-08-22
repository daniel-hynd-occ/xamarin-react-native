using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Facebook.React.Bridge;
using Java.Interop;
using Java.Lang;

namespace SampleApp.Droid
{
    public class ToastModule : ReactContextBaseJavaModule
    {
        public override string Name => "ToastExample";

        public override IDictionary<string, Java.Lang.Object> Constants =>
            new Dictionary<string, Java.Lang.Object>
            {
                { DURATION_SHORT_KEY, (int)ToastLength.Short },
                { DURATION_LONG_KEY, (int)ToastLength.Long },
            };

        public static readonly string DURATION_SHORT_KEY = "SHORT";
        public static readonly string DURATION_LONG_KEY = "LONG";

        public ToastModule(ReactApplicationContext context)
            : base(context)
        {
        }

        [ReactMethod]
        [Export("show")]
        public void Show(string message)
        {
            Toast.MakeText(ReactApplicationContext, message, ToastLength.Long).Show();
        }
    }
}