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
using SharedCode;

namespace SampleApp.Droid
{
    public class RandomNumberModule : ReactContextBaseJavaModule
    {
        public override string Name => "RNG";

        public RandomNumberModule(ReactApplicationContext context)
            : base(context)
        {
        }

        [ReactMethod]
        [Export("next")]
        public void next(ICallback errorCallback, ICallback successCallback)
        {
            try
            {
                successCallback.Invoke(RNG.Next());
            }
            catch(Exception e)
            {
                errorCallback.Invoke(e.Message);
            }
        }

        [ReactMethod]
        [Export("nextAsString")]
        public void nextAsString(ICallback errorCallback, ICallback successCallback)
        {
            try
            {
                successCallback.Invoke(RNG.Next().ToString());
            }
            catch (Exception e)
            {
                errorCallback.Invoke(e.Message);
            }
        }

        [ReactMethod]
        [Export("nextNegative")]
        public void nextNegative(int min, int max, IPromise promise)
        {
            try
            {
                var range = max - min;
                var random = min + (RNG.Next() % range);
                var numFuncs = new NumberFunctions();
                promise.Resolve(numFuncs.MakeNegative(random));
            }
            catch(Exception e)
            {
                promise.Reject(e.Message, new Java.Lang.Exception(e.Message));
            }
        }
    }
}