
namespace EasyTravel.Services
{
    public interface IGeoService
    {
        void GetLatLongFromAddress(string street, string city, string state);
    }
}
