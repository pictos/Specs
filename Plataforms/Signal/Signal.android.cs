using Android.App;
using Android.Net.Wifi;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace Plataforms
{
    public static partial class Signal
    {
        public static Activity Current { get; set; }
        static int PlataformSignal()
        {
            if (Current is null)
                throw new ArgumentNullException(nameof(Current));

            var wifiManager = (WifiManager)Current.GetSystemService(Android.Content.Context.WifiService);

            var info = wifiManager.ConnectionInfo;

            var lvl = WifiManager.CalculateSignalLevel(info.Rssi, 5);

            return lvl;
        }
    }
}
