using Plataforms;
using Specs.ViewModels;
using Xamarin.Forms;

namespace Specs.Views
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ContactViewModel).InitializeAsync(null).Wait();
        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(!(e.Item is PhoneContact contact)) return;

            var info = $"Number: {contact.Number} Email: {contact.Email}";

            await DisplayAlert(contact.Name, info, "ok");
        }
    }
}