using Plataforms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Specs.ViewModels
{
    sealed class ContactViewModel : BaseViewModel
    {
        public ObservableCollection<PhoneContact> Contacts { get; private set; } = new ObservableCollection<PhoneContact>();

        public override Task InitializeAsync(object[] args)
        {
            var contacts = Plataforms.Contacts.GetContacts();

            foreach (var item in contacts)
                Contacts.Add(item);

            return base.InitializeAsync(args);
        }
    }
}
