using Specs.Services;
using Specs.UWP.Services;
using Windows.Networking.Connectivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalUWP))]


namespace Specs.UWP.Services
{
    public class SignalUWP : IWifi
    {
        public string SignalStrength()
        {

            var result = string.Empty;
            var t = NetworkInformation.GetInternetConnectionProfile(); // RedeConectada

            //https://stackoverflow.com/questions/39778105/how-to-programatically-detect-a-weak-internet-signal-strength-internet-wi-fi-c
            foreach (ConnectionProfile profile in NetworkInformation.GetConnectionProfiles()) //Get all active profiles (LAN, bluetooth, wifi, Cellular data, etc..)
            {
                NetworkConnectivityLevel level = profile.GetNetworkConnectivityLevel(); //Get connectivity level for profile
                                                                                        /*NetworkConnectivityLevel.InternetAccess         
                                                                                                                   ConstrainedInternetAccess
                                                                                                                   LocalAccess
                                                                                                                   None*/
                var signal = profile.GetSignalBars(); //Returns the signal level
                bool isWifi = profile.IsWlanConnectionProfile;
                bool isCellularData = profile.IsWwanConnectionProfile;
                result += $" {signal}";
            }
            return result;
            
        }

     
    }
}
