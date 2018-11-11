using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Foundation;
using ObjCRuntime;
using ReactNative.iOS;
using UIKit;

namespace SampleApp.iOS
{
    public class RandomNumberModule : RCTBridgeModule
    {
        [Export("moduleName")]
        public static string ModuleName() => "RNG";

        [Export("requiresMainQueueSetup")]
        public static bool RequiresMainQueueSetup => false;

        public delegate void RCTPromiseResolveBlock(NSObject result);
        public delegate void RCTPromiseRejectBlock(NSString code, NSString message, NSError error);

        //[Export("test:resolve:reject")]
        //public void Test(RCTPromiseResolveBlock resolve, RCTPromiseRejectBlock reject)
        //{
        //    resolve(NSObject.FromObject("resolved"));
        //}

        [Export("test:")]
        public void Test(string msg) => Debug.WriteLine(msg);

        [Export("__rct_export__test")]
        public static IntPtr TestExport()
        {
            var temp = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "test: (NSString*) msg",
                isSync = false
            };
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(temp));

            Marshal.StructureToPtr(temp, ptr, false);

            return ptr;
        }

        //[Export("notify:")]
        //public void NotifyMe(RCTResponseSenderBlock callback)
        //{
        //    var array = new object[] { null, "done" };

        //    Debug.WriteLine("notified");
        //}

        //[Export("__rct_export__notify")]
        //public static IntPtr NotifyMeExport()
        //{
        //    var method = new RCTMethodInfo()
        //    {
        //        jsName = string.Empty,
        //        objcName = "notify:(RCTResponseSenderBlock)callback",
        //        isSync = false
        //    };

        //    var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(method));
        //    Marshal.StructureToPtr(method, ptr, false);

        //    return ptr;
        //}
    }
}