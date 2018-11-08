using NetworkExtension;

namespace Plataforms
{
    public static partial class Signal
    {
        static int PlataformSignal()
        {
            var p = new NEHotspotNetwork();
            var signal = (int)(p.SignalStrength) * 5; // Normalize 0 - 1 to 0 - 5
            return signal;
        }
    }
}
