using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
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
        public delegate void RCTPromiseRejectBlock(ref NSString code, ref NSString message, ref NSError error);
    }
}