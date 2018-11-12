using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        [Export("addOne::")]
        public override void AddOne(int x, RCTResponseSenderBlock callback)
        {
            var result = FromObject(x + 1);
            callback(new[] { NSNull.Null, result });
        }

        [Export("__rct_export__addOne")]
        public static IntPtr AddOneExport()
        {
            var method = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "addOne:(int)x:(RCTResponseSenderBlock)callback",
                isSync = false
            };

            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(method));
            Marshal.StructureToPtr(method, ptr, false);

            return ptr;
        }

        /* This will throw "ObjCRuntime.RuntimeException: Unable to locate the block to delegate conversion method for the method SampleApp.iOS.RandomNumberModule.AddTwo's parameter #2. Please file a bug at http://bugzilla.xamarin.com."
         
        [Export("addTwo::")]
        public void AddTwo(int x, RCTResponseSenderBlock callback)
        {
            var result = FromObject(x + 2);
            callback(new[] { NSNull.Null, result });
        }

        [Export("__rct_export__addTwo")]
        public static IntPtr AddTwoExport()
        {
            var method = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "addTwo:(int)x:(RCTResponseSenderBlock)callback",
                isSync = false
            };

            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(method));
            Marshal.StructureToPtr(method, ptr, false);

            return ptr;
        }*/

        [Export("square::rejecter:")]
        public override void Square(int x, RCTPromiseResolveBlock resolve, RCTPromiseRejectBlock reject)
        {
            resolve(FromObject(x * x));
        }

        [Export("__rct_export__square")]
        public static IntPtr SquareExport()
        {
            var method = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "square:(int)x:(RCTPromiseResolveBlock)resolve rejecter:(RCTPromiseRejectBlock)reject",
                isSync = false
            };

            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(method));
            Marshal.StructureToPtr(method, ptr, false);

            return ptr;
        }
    }
}