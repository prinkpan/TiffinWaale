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

[assembly: Dependency(typeof(DialerHelper))]
namespace TiffinWaale.Droid
{
    public class DialerHelper : IDialer
    {
        internal Context Context { get; set; }

        public bool MakeCall(string phoneNumber)
        {
            if (Context == null)
                return false;
            try
            {
                var URI = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));
                var intent = new Intent(Intent.ActionDial, URI);
                Context.StartActivity(intent);
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
    }
}