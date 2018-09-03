using System;
using System.Runtime.InteropServices;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace ReactNative.iOS
{
    [BaseType(typeof(NSObject))]
    interface RCTBundleURLProvider
    {
        // +(instancetype)sharedSettings;
        [Static]
        [Export("sharedSettings")]
        RCTBundleURLProvider SharedSettings();

        // -(NSURL *)jsBundleURLForBundleRoot:(NSString *)bundleRoot fallbackResource:(NSString *)resourceName;
        [Export("jsBundleURLForBundleRoot:fallbackResource:")]
        NSUrl JsBundleURLForBundleRoot(string bundleRoot, [NullAllowed] string resourceName);
    }

    [BaseType(typeof(UIView))]
    interface RCTRootView
    {
        [ExportAttribute("initWithBundleURL:moduleName:initialProperties:launchOptions:")]
        IntPtr Constructor(NSUrl bundleUrl, NSString moduleName, NSDictionary initialProperties, NSDictionary launchOptions);
    }

    // @protocol RCTBridgeModule <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface RCTBridgeModule
    {

    }
}
