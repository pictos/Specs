using Plataforms;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Specs.ViewModels
{
    sealed class ContactViewModel : BaseViewModel
    {
        public ObservableCollection<PhoneContact> Contacts { get; private set; } = new ObservableCollection<PhoneContact>();

        public Command LoadCommand => new Command(LoadCommandExecute);

        ManualResetEvent mre = new ManualResetEvent(true);

        void LoadCommandExecute()
        {
            Plataforms.Contacts.GetContacts(10);

            Thread.Sleep(2000);

            mre.Set();
        }

        public ContactViewModel()
        {
            Plataforms.Contacts.CallBack += Contacts_CallBack;
            Plataforms.Contacts.GetContacts(10);
        }

        public override async Task InitializeAsync(object[] args)
        {



            //return base.InitializeAsync(args);
        }

        void Contacts_CallBack(object sender, CallBackArgs e)
        {

            Contacts.Clear();
            mre = e.Mre;
            foreach (var item in e.Phones)
            {
                Contacts.Add(item);
            }

        }
    }
}
