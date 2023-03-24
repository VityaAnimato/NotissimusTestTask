using System;
using System.Text.Json;
using System.Xml.Serialization;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using NotissimusTestTask.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Android.Content;
using NotissimusTestTask.Resources;
using System.Text.Encodings.Web;
using System.Text;
using System.Text.Unicode;
using NotissimusTestTask.Views;
using NotissimusTestTask.Presenters;

namespace NotissimusTestTask
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class OffersListActivity : AppCompatActivity, IOffersListView
    {
        private OffersListPresenter presenter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_offers_list);

            presenter = new OffersListPresenter(this);
            await presenter.LoadOffers();

            var mainListView = (ListView)FindViewById(Resource.Id.offersListView);
            var offersId = presenter.Offers.Select(o => o.Id).ToList();
            mainListView.Adapter = new ArrayAdapter(this, Resource.Layout.offer_list_item, offersId);
            mainListView.ItemClick += (sender, e) => {
                var currentOffer = presenter.Offers[(int)e.Id];
                presenter.OnOfferClick(currentOffer);
            };
        }
        public void HideLoading()
        {
            var offersLoadingBar = (ProgressBar)FindViewById(Resource.Id.offersLoadingBar);
            offersLoadingBar.Visibility = ViewStates.Invisible;
        }
        public void OpenOfferDetail(string offerJson)
        {
            var intent = new Intent(this, typeof(OfferDetailActivity));
            intent.PutExtra(OfferDetailActivity.JsonOfferExtraKey, offerJson);
            StartActivity(intent);
        }

        public void ShowLoading()
        {
            var offersLoadingBar = (ProgressBar)FindViewById(Resource.Id.offersLoadingBar);
            offersLoadingBar.Visibility = ViewStates.Visible;
        }
	}
}
