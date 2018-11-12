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
        /* These are placeholders for functions with block parameters exported from implementation modules.
         * Required in order to generate the corresponding block conversions and to avoid an exception.
         * Actual module should override this function with the implementation. */
        [Export("addOne::")]
        void AddOne(int x, RCTResponseSenderBlock response);

        [Export("square::rejecter:")]
        void Square(int x, RCTPromiseResolveBlock resolve, RCTPromiseRejectBlock reject);
    }    // typedef void (^RCTResponseSenderBlock)(NSArray *);

    public delegate void RCTResponseSenderBlock(NSObject[] response);

    // typedef void (^RCTResponseErrorBlock)(NSError *);
    public delegate void RCTResponseErrorBlock(NSError error);

    // typedef void (^RCTPromiseResolveBlock)(id);
    public delegate void RCTPromiseResolveBlock(NSObject result);

    // typedef void (^RCTPromiseRejectBlock)(NSString *, NSString *, NSError *);
    public delegate void RCTPromiseRejectBlock(string code, string message, NSError error);

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
