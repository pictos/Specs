using NetworkExtension;

namespace Plataforms
{
    public static partial class Signal
    {
        static SignalStrength PlataformSignal()
        {
            var p = new NEHotspotNetwork();

            if (p is null)
                return SignalStrength.Unknown;

            var lvl = (int)(p?.SignalStrength) * 5; // Normalize 0 - 1 to 0 - 5
            return GetSignal(lvl);
        }
    }
}
