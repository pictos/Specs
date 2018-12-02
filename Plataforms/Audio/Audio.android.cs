using Android.App;
using Android.Content;
using Android.Media;
using System;

namespace Plataforms
{
    static partial class Audio
    {
        public static Activity Current => Signal.Current;

        static AudioManager am;

        static void PlataformRingTone()
        {
            GetAudioManager();
            am.RingerMode = RingerMode.Normal;
        }

        static void PlataformIncreaseVolume(int volume)
        {
            GetAudioManager();
            am = (AudioManager)Current.GetSystemService(Context.AudioService);
            am.SetStreamVolume(Stream.Alarm, volume, VolumeNotificationFlags.ShowUi);

            //for (int i = 0; i < volume; i++)
            //    am.AdjustSuggestedStreamVolume(Adjust.Raise, Stream.Alarm, VolumeNotificationFlags.ShowUi);
        }

        static void GetAudioManager()
        {
            if (Current is null)
                throw new Exception("Activity is null. Please set the current Activity");

            am = (AudioManager)Current.GetSystemService(Context.AudioService);

            if (am.IsVolumeFixed)
                throw new Exception("The volume is fixed so you can't change it!");
        }
    }
}
