using Android.Content;
using Android.Net.Wifi;
using Specs.Droid.Services;
using Specs.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalAndroid))]

namespace Specs.Droid.Services
{
    public class SignalAndroid : IWifi
    {
        //https://stackoverflow.com/questions/18831442/how-to-get-signal-strength-of-connected-wifi-android
        //Necessita permissão de Wifi_State
        public string SignalStrength()
        {

            var result = string.Empty;

            var wifiManager = (WifiManager)MainActivity.Current.GetSystemService(Context.WifiService);

            var info = wifiManager.ConnectionInfo;

            var lvl = WifiManager.CalculateSignalLevel(info.Rssi, 4);

            return lvl.ToString();         
        }
    }
}