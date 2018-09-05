using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ReactNative.iOS;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SampleApp.iOS
{
    public class ToastExampleModule : RCTBridgeModule
    {
        [Export("moduleName")]
        public static string ModuleName() => "ToastExample";

        [Export("requiresMainQueueSetup")]
        public static bool RequiresMainQueueSetup => false;

        [Export("show:")]
        public void Show(string msg)
        {
            InvokeOnMainThread(() =>
            {
                var alert = new UIAlertView()
                {
                    Title = "An Alert",
                    Message = "This is an iOS native alert, " + msg
                };
                alert.AddButton("OK");
                alert.Show();
            });
        }

        [Export("__rct_export__show")]
        public static IntPtr ShowExport()
        {
            var info = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "show: (NSString*) msg",
                isSync = false
            };

            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(info));
            Marshal.StructureToPtr(info, ptr, false);
            return ptr;
        }
    }
}