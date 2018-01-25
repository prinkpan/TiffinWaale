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
using TiffinWaale.Services;
using Xamarin.Forms;
using TiffinWaale.Droid;
using TiffinWaale.Helper;

[assembly: Dependency(typeof(AndroidDialer))]
namespace TiffinWaale.Droid
{
    public class AndroidDialer : IDialer
    {
        public void MakeCall(string phoneNumber)
        {
            try
            {
                var URI = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));
                var intent = new Intent(Intent.ActionCall, URI);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}