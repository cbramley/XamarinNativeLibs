using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Runtime.InteropServices;

namespace BasicNDK
{
    [Activity (Label = "BasicNDK", MainLauncher = true)]
    public class Activity1 : Activity
    {
        [DllImport ("ndksample")]
        static extern void LogNdk ( IntPtr jnienv, IntPtr thiz, string w );
        
        [DllImport ("ndksample")]
        static extern void LogNdk ( string w );
        
        [DllImport ("ndksample")]
        static extern void LogNdkNewTag ( IntPtr jnienv, IntPtr thiz, string w );
        
        [DllImport ("ndksample")]
        static extern void LogNdkNewTag ( string w );

        [DllImport ("ndksample")]
        static extern void LogNdkDefaultMessage ( IntPtr jnienv, IntPtr thiz );
        
        [DllImport ("ndksample")]
        static extern void LogNdkDefaultMessage ();

        protected override void OnCreate ( Bundle bundle )
        {
            base.OnCreate ( bundle );
            SetContentView ( Resource.Layout.Main );

            Button button = FindViewById<Button> ( Resource.Id.myButton );            
            button.Click += delegate
            {
                // launch our NDK code

                try
                {
                    LogNdkDefaultMessage( JNIEnv.Handle, JNIEnv.Handle);
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("Main",e.ToString());
                }
                
                try
                {
                    LogNdkDefaultMessage();
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("MainShort",e.ToString());
                }

                try
                {
                    LogNdk("Message to log");
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("MainShort",e.ToString());
                }

                try
                {
                    LogNdk( JNIEnv.Handle, JNIEnv.Handle, "Message to log");
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("Main",e.ToString());
                }

                try
                {
                    LogNdkNewTag(IntPtr.Zero, IntPtr.Zero, "Message to log");
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("Main",e.ToString());
                }
                
                try
                {
                    LogNdkNewTag("Message to log");
                }
                catch (Exception e)
                {
                    Android.Util.Log.Warn("MainShort",e.ToString());
                }               
            };
        }
    }
}