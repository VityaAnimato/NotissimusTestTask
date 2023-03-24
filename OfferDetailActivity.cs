using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotissimusTestTask.Models;
using NotissimusTestTask.Resources;
using Android.Support.V7.App;

namespace NotissimusTestTask.Resources
{
    [Activity(Label = "@string/app_name")]
    public class OfferDetailActivity : AppCompatActivity
    {
        public const string JsonOfferExtraKey = "JSON_OFFER";
        private string jsonOffer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_offer_detail);
            jsonOffer = Intent.Extras.GetString(JsonOfferExtraKey);
            ((EditText)FindViewById(Resource.Id.offerJsonText)).Text = jsonOffer;
        }
    }
}