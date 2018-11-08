using NetworkExtension;
using Specs.iOS.Services;
using Specs.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignaliOS))]

namespace Specs.iOS.Services
{
    //https://stackoverflow.com/questions/32970711/is-it-possible-to-get-wifi-signal-strength-in-ios-9#32970967
    public class SignaliOS : IWifi
    {
        public string Signal => SignalStrength();
        public string SignalStrength()
        {
            var p = new NEHotspotNetwork();
            var signal = (int)(p.SignalStrength) * 5; // Normalize 0 - 1 to 0 - 5
            return signal.ToString();
        }
    }
}