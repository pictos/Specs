using Plataforms;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Specs.ViewModels
{
    sealed class ContactViewModel : BaseViewModel
    {
        public ObservableCollection<PhoneContact> Contacts { get; private set; } = new ObservableCollection<PhoneContact>();

        public Command LoadCommand => new Command(async () => await LoadCommandExecute());

        ManualResetEvent mre = new ManualResetEvent(true);

        async Task LoadCommandExecute()
        {

            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var watch = new Stopwatch();
                    watch.Start();
                    var contacts = await Plataforms.Contacts.GetContacts(10);
                    watch.Stop();

                    contacts = contacts.OrderBy(x => x.Name);

                    await DisplayAlert("Tempo da query", watch.ElapsedMilliseconds.ToString());

                    foreach (var item in contacts)
                        Contacts.Add(item);
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return;
            //Thread.Sleep(2000);

            //mre.Set();
        }

        public ContactViewModel()
        {
           // Plataforms.Contacts.CallBack += Contacts_CallBack;
           // Plataforms.Contacts.GetContacts(10);
        }

        public override Task InitializeAsync(object[] args)
        {
            return base.InitializeAsync(args);
        }

        void Contacts_CallBack(object sender, CallBackArgs e)
        {

            Contacts.Clear();
            mre = e.Mre;
            foreach (var item in e.Phones)
                Contacts.Add(item);
        }
    }
}
