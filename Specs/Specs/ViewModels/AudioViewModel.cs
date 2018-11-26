using Xamarin.Forms;

namespace Specs.ViewModels
{
    sealed class AudioViewModel : BaseViewModel
    {

        private int volume;

        public int Volume
        {
            get { return volume; }
            set { SetProperty(ref volume, value); }
        }
        public Command IncreaseCommand => new Command(ExecuteIncreaseCommand);

        void ExecuteIncreaseCommand()
        {
            Plataforms.Audio.IncreaseVolume(Volume);
        }
    }
}
