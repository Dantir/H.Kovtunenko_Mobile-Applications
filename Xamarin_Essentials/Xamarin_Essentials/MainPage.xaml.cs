using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin_Essentials
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Longitude:" + location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Failed", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Failed", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message, "OK");
            }

        }

        private async void btnNavigate_Clicked(object sender, EventArgs e)
        {
            await NavigateToBuilding25();
        }

        public async Task NavigateToBuilding25()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var cts = new CancellationTokenSource();
            var location1 = await Geolocation.GetLocationAsync(request, cts.Token);
            var location2 = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
            double kilometers = Math.Ceiling(Location.CalculateDistance(location1,location2, DistanceUnits.Kilometers));
            distance.Text = "Kilometers to nearest building:" + kilometers;
            //await Map.OpenAsync(location, options);
        }

        private async void btnShare_Clicked(object sender, EventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = $"Latitude: {location.Latitude.ToString()}. Longtitude: {location.Longitude.ToString()} ",
                Title = "My current location"
            });
        }
    }
}
