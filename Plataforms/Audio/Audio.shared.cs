using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforms
{
    public static partial class Audio
    {
        public static void ChangingRingTone() => PlataformRingTone();

        public static void IncreaseVolume(int volume) => PlataformIncreaseVolume(volume);

    }
}
