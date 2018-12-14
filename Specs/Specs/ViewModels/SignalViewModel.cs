using System.Threading.Tasks;
using Xamarin.Forms;

namespace Specs.ViewModels
{
    sealed class SignalViewModel : BaseViewModel
    {

        private string signal;

        public string Signal
        {
            get { return signal; }
            set { SetProperty(ref signal, value); }
        }
        public Command SignalCommand => new Command(ExecuteSignalCommand);

        void ExecuteSignalCommand() => 
            Signal = $" Signal power : {Plataforms.Signal.SignalStrenght}";

        public override Task Initialize(object[] args)
        {
            Signal = $" Signal power : {Plataforms.Signal.SignalStrenght}";
            return Task.CompletedTask;
        }
    }
}
