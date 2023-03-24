
using NotissimusTestTask.Models;

namespace NotissimusTestTask.Views
{
    public interface IOffersListView : ILoadingView
    {
        public void OpenOfferDetail(string offerJson);
    }
}