using TuraProductsAPI.Services.Parcel;

namespace TuraProductsAPI.Services
{
    public class ParcelService
    {
        public ParcelContainer GetParcelContainer(string invoiceId)
        {
            return new ParcelCreatorFactory(invoiceId).GetParcelNumbers();
        }
    }
}
