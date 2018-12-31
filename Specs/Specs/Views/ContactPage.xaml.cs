using Plataforms;
using Specs.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    (BindingContext as ContactViewModel).InitializeAsync(null).Wait();
        //}

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(!(e.Item is PhoneContact contact)) return;
           // string numbers = List2String(contact.Numbers);
            string emails = List2String(contact.Emails);

            var info = $"Number: {contact.Numbers?[0]} Email: {emails}";

            await DisplayAlert(contact.Name, info, "ok");

            (sender as ListView).SelectedItem = null;
        }

        string List2String(IEnumerable<string> contacts)
        {
            if (contacts.Count() == 0) return string.Empty;

            string x = null;

            foreach (var item in contacts)            
                x += item + ",";

            return x;
        }

        void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                Debug.WriteLine(((PhoneContact)e.Item).Name);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}