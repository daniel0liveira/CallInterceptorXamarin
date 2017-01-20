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
using Android.Telephony;
using Java.Lang;
using Java.Lang.Reflect;
using Android.Provider;

namespace XamarinCallInterceptor
{
    [BroadcastReceiver()]
    [IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]
    public class CallIncomingReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Extras != null)
            {
                // get the incoming call state
                string state = intent.GetStringExtra(TelephonyManager.ExtraState);

                // check the current state
                if (state == TelephonyManager.ExtraStateRinging)
                {
                    // read the incoming call telephone number...
                    string telephone = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    if (telephone.Equals("0000000"))
                    {
                        TelephonyManager mng = (TelephonyManager)context.GetSystemService(Context.TelephonyService);

                        IntPtr iTelephonyPtr = JNIEnv.GetMethodID(mng.Class.Handle, "getITelephony", "()Lcom/android/internal/telephony/ITelephony;");

                        IntPtr telephony = JNIEnv.CallObjectMethod(mng.Handle, iTelephonyPtr);
                        IntPtr iTelephonyClass = JNIEnv.GetObjectClass(telephony);
                        IntPtr iTelephonyEndCall = JNIEnv.GetMethodID(iTelephonyClass, "endCall", "()Z");
                        JNIEnv.CallBooleanMethod(telephony, iTelephonyEndCall);
                        JNIEnv.DeleteLocalRef(telephony);
                        JNIEnv.DeleteLocalRef(iTelephonyClass);
                    }
                  
                }
                else if (state == TelephonyManager.ExtraStateOffhook)
                {
                    // incoming call answer
                }
                else if (state == TelephonyManager.ExtraStateIdle)
                {
                    // incoming call end
                }
            }
        }
    }
}
