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

    // typedef void (^RCTResponseSenderBlock)(NSArray *);
    delegate void RCTResponseSenderBlock(NSObject[] arg0);

    // typedef void (^RCTResponseErrorBlock)(NSError *);
    delegate void RCTResponseErrorBlock(NSError arg0);

    // typedef void (^RCTPromiseResolveBlock)(id);
    delegate void RCTPromiseResolveBlock(NSObject arg0);

    // typedef void (^RCTPromiseRejectBlock)(NSString *, NSString *, NSError *);
    delegate void RCTPromiseRejectBlock(string arg0, string arg1, NSError arg2);

    // @interface RCTEventEmitter : NSObject<RCTBridgeModule>
    [BaseType(typeof(NSObject))]
    interface RCTEventEmitter : RCTBridgeModule
    {
        [Export("sendEventWithName:body:")]
        void SendEventWithName(string name, NSObject body);

        // -(void)startObserving;
        [Export("startObserving")]
        void StartObserving();

        // -(void)stopObserving;
        [Export("stopObserving")]
        void StopObserving();

        // -(void)addListener:(NSString *)eventName;
        [Export("addListener:")]
        void AddListener(string eventName);

        // -(void)removeListeners:(double)count;
        [Export("removeListeners:")]
        void RemoveListeners(double count);
    }
}
