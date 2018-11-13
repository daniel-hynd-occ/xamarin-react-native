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
using Com.Facebook.React.Modules.Core;
using Java.Interop;
using static Com.Facebook.React.Modules.Core.DeviceEventManagerModule;

namespace SampleApp.Droid
{
    public class EventsModule : ReactContextBaseJavaModule
    {
        public override string Name => "Events";

        public EventsModule(ReactApplicationContext context)
            : base(context)
        {
        }

        public static void Emit(ReactApplicationContext context, string name, Java.Lang.Object data)
        {
            Java.Lang.Class emitterClass = Java.Lang.Class.FromType(typeof(IRCTNativeAppEventEmitter));
            Java.Lang.Object module = context.GetJSModule(emitterClass);
            IRCTNativeAppEventEmitter emitter = Android.Runtime.Extensions.JavaCast<IRCTNativeAppEventEmitter>(module);

            emitter.Emit(name, data);
        }

        [ReactMethod]
        [Export("send")]
        public void Send()
        {
            var map = new WritableNativeMap();
            map.PutInt("int", 123);
            map.PutBoolean("bool", true);

            var array = new WritableNativeArray();
            array.PushInt(10);
            array.PushString("why");
            map.PutArray("array", array);

            Emit(ReactApplicationContext, "AnEvent", map);
        }
    }
}