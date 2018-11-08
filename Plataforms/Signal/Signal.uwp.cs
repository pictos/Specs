using Windows.Networking.Connectivity;

namespace Plataforms
{
    public static partial class Signal
    {
        static SignalStrength PlataformSignal()
        {
            var t = NetworkInformation.GetInternetConnectionProfile(); // RedeConectada

            if (t is null)
                return SignalStrength.Unknown;

            var lvl = int.Parse(t.GetSignalBars().ToString());
            return GetSignal(lvl);
        }    
    }
}
