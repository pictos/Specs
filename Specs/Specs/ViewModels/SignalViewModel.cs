using Specs.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        public override Task InitializeAsync(object[] args)
        {
          //  Signal = DependencyService.Get<IWifi>().SignalStrength();
            Signal = $" Signal power : {Plataforms.Signal.SignalStrenght}";
            return Task.CompletedTask;
        }
    }
}
