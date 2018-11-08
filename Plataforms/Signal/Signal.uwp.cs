using Windows.Networking.Connectivity;

namespace Plataforms
{
    public static partial class Signal
    {
        static int PlataformSignal()
        {           
            var t = NetworkInformation.GetInternetConnectionProfile(); // RedeConectada

            //https://stackoverflow.com/questions/39778105/how-to-programatically-detect-a-weak-internet-signal-strength-internet-wi-fi-c
            foreach (ConnectionProfile profile in NetworkInformation.GetConnectionProfiles()) //Get all active profiles (LAN, bluetooth, wifi, Cellular data, etc..)
            {
                NetworkConnectivityLevel level = profile.GetNetworkConnectivityLevel();
                var signal = profile.GetSignalBars(); //Returns the signal level
                bool isWifi = profile.IsWlanConnectionProfile;
                bool isCellularData = profile.IsWwanConnectionProfile;
                
            }
            return int.Parse(t.GetSignalBars().ToString());
        }
    }
}
