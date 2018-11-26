using Android.App;
using Android.Net.Wifi;
using System;

namespace Plataforms
{
    public static partial class Signal
    {
        public static Activity Current { get; set; }
        static SignalStrength PlataformSignal()
        {
            if (Current is null)
                throw new ArgumentNullException(nameof(Current));

            var wifiManager = (WifiManager)Current.GetSystemService(Android.Content.Context.WifiService);

            var info = wifiManager?.ConnectionInfo;

            if(info is null)
                return SignalStrength.Unknown;

            var lvl = WifiManager.CalculateSignalLevel(info.Rssi, 6);

            return GetSignal(lvl);
        }
    }
}
