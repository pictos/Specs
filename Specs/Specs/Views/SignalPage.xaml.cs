using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Specs.Views
{
    public partial class SignalPage : ContentPage
    {
        public SignalPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SignalViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ViewModels.SignalViewModel).InitializeAsync(null);
        }
    }
}