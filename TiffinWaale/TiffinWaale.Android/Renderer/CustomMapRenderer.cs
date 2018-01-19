using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TiffinWaale.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(TiffinWaale.Droid.Renderer.CustomMapRenderer))]
namespace TiffinWaale.Droid.Renderer
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        public CustomMapRenderer(Context context) : base(context)
        {

        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var cpin = pin as CustomPin;
            var hue = (float)cpin.Color.Hue % 1F * 360F;
            var alpha = (float)cpin.Opacity;

            var opts = new MarkerOptions();
            opts.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            opts.SetTitle(pin.Label);
            opts.SetSnippet(pin.Address);

            return opts;
        }
    }
}