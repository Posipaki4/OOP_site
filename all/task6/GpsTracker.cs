using System;

namespace Lab6
{
    public class GpsTracker
    {
        private double latitude;
        private double longitude;

        public GpsTracker()
        {
            latitude = 50.4501;
            longitude = 30.5234;
        }

        public void UpdateLocation(double lat, double lon)
        {
            latitude = lat;
            longitude = lon;
        }

        public string GetLocation()
        {
            return $"{latitude}, {longitude}";
        }
    }
}
