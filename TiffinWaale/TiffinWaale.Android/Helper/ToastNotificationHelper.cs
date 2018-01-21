﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TiffinWaale.Droid.Helper;
using TiffinWaale.Helper;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastNotificationHelper))]
namespace TiffinWaale.Droid.Helper
{
    public class ToastNotificationHelper : IToastNotification
    {
        public void LongTime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortTime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}