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
using Com.Facebook.React;
using Com.Facebook.React.Bridge;
using Com.Facebook.React.Uimanager;

namespace SampleApp.Droid
{
    public class ApiPackage : Java.Lang.Object, IReactPackage
    {
        public IList<INativeModule> CreateNativeModules(ReactApplicationContext reactContext)
        {
            return new List<INativeModule>
            {
                new ToastModule(reactContext),
                new RandomNumberModule(reactContext),
                new EventsModule(reactContext)
            };
        }

        public IList<ViewManager> CreateViewManagers(ReactApplicationContext reactContext)
        {
            return new List<ViewManager>();
        }
    }
}