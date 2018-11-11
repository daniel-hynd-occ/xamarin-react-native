using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Foundation;
using ReactNative.iOS;

namespace SampleApp.iOS
{
    public class EventsModule : RCTEventEmitter
    {
        private const string AN_EVENT_NAME = "AnEvent";

        [Export("moduleName")]
        public static string ModuleName() => "Events";

        [Export("requiresMainQueueSetup")]
        public static bool RequiresMainQueueSetup => false;

        // Emitting an event whilst there are no listeners will generate a warning: https://facebook.github.io/react-native/docs/native-modules-ios#optimizing-for-zero-listeners
        // TODO: Check that start & stopObserving() can be overridden to update hasListeners state
        private bool hasListeners = true;

        /* Sending an event or registering a listener using an event name not in this array will generate an error */
        [Export("supportedEvents")]
        public string[] SupportedEvents =>new string[] { AN_EVENT_NAME };

        /* Export React methods that allow events to be sent */
        [Export("send")]
        public void SendEvents()
        {
            if (hasListeners)
            {
                /* The event body can be any of: https://facebook.github.io/react-native/docs/native-modules-ios#argument-types */
                /* Some types they can be instantiated directly, e.g. new NSString("A string"), others require boxing via NSObject.FromObject() or similar. */

                /* The below allows constructing objects with arbritrary key-value pairs in a "semi-general" way */
                Dictionary<string, object> body = new Dictionary<string, object>{
                    { "name", "An event 123" },
                    { "time", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }
                };
                NSDictionary nsBody = NSDictionary.FromObjectsAndKeys(
                    body.Values.Select(v => FromObject(v)).ToArray(),
                    body.Keys.Select(k => FromObject(k)).ToArray()
                );

                SendEventWithName(AN_EVENT_NAME, nsBody);
            }
        }

        [Export("__rct_export__send")]
        public static IntPtr SendEventsExport()
        {
            var temp = new RCTMethodInfo()
            {
                jsName = string.Empty,
                objcName = "send",
                isSync = false
            };
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(temp));

            Marshal.StructureToPtr(temp, ptr, false);

            return ptr;
        } 
    }
}