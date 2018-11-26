using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Specs.Views
{
    public partial class AudioPage : ContentPage
    {
        public AudioPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AudioViewModel();
        }
    }
}