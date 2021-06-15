namespace EasyTravel.Services
{
    using System.Text.RegularExpressions;
    using System.Xml;

    public class GeoService : IGeoService
    {

        public void GetLatLongFromAddress(string street, string city, string state)
        {
            string geocoderUri = string.Format($"https://rpc.geocoder.us/service/rest?address={0},{1},{2}", street, city, state);
            XmlDocument geocoderXmlDoc = new XmlDocument();
            geocoderXmlDoc.Load(geocoderUri);
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(geocoderXmlDoc.NameTable);
            nsMgr.AddNamespace("geo", @"https://www.w3.org/2003/01/geo/wgs84_pos#");
            string sLong = geocoderXmlDoc.DocumentElement.SelectSingleNode(@"//geo:long", nsMgr).InnerText;
            string sLat = geocoderXmlDoc.DocumentElement.SelectSingleNode(@"//geo:lat", nsMgr).InnerText;

           var Latitude = double.Parse(sLat);
           var Longitude = double.Parse(sLong);
        }
    }
}
