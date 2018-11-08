namespace Plataforms
{
    public static partial class Signal
    {
        public static SignalStrength SignalStrenght => PlataformSignal();

        internal static SignalStrength GetSignal(int lvl)
        {
            switch (lvl)
            {
                case 0:
                    return SignalStrength.None;
                case 1:
                    return SignalStrength.Weak;
                case 2:
                    return SignalStrength.Weak;
                case 3:
                    return SignalStrength.Fair;
                case 4:
                    return SignalStrength.Strong;
                case int n when(n > 4):
                    return SignalStrength.Strong;
                default:
                    return SignalStrength.Unknown;
            }
        }
    }
}
