using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotissimusTestTask.Models;
using NotissimusTestTask.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace NotissimusTestTask.Presenters
{
    class OffersListPresenter
    {
        private readonly IOffersListView view;
        public OffersListPresenter(IOffersListView view)
        {
            this.view = view;
        }
        public IList<Offer> Offers { get; private set; }
        public async Task LoadOffers()
        {
            view.ShowLoading();
            var ymlCatalog = await YmlCatalog.GetTestDataAsync();
            Offers = ymlCatalog.Shop.Offers.Offer;
            view.HideLoading();
        }

        public void OnOfferClick(Offer offer)
        {
            var offerByteJson = JsonSerializer.SerializeToUtf8Bytes(offer, options: new JsonSerializerOptions()
            {
                IgnoreNullValues = true,
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });
            var offerJson = new string(Encoding.UTF8.GetString(offerByteJson)); ;
            view.OpenOfferDetail(offerJson);
        }
    }
}