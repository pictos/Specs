using System;
using System.Linq;
using System.Collections.Generic;

using Windows.ApplicationModel.Contacts;
using System.Threading.Tasks;

namespace Plataforms
{
    static partial class Contacts
    {
        static async Task<IEnumerable<PhoneContact>> PlataformGetContacts(int pageSize)
        {
            var phoneContacts = new List<PhoneContact>();

            var contactStore = await ContactManager.RequestStoreAsync();
            var contacts = await contactStore.FindContactsAsync();

            var i = 0;

            foreach (var item in contacts)
            {
                Manualreset.WaitOne();

                #region UiThread!

                //if (ncontact == i)
                //{
                //    Manualreset.Reset();
                //    CallBack?.Invoke(null, new CallBackArgs(Manualreset, phoneContacts));
                //} 
                #endregion

                var phones = item.Phones.Select(p => p.Number);
                var emails = item.Emails.Select(e => e.Address);
                var address = item.Addresses.Select(a => a.StreetAddress);
                var name = item.FirstName + item.MiddleName + item.LastName;
                var date = item.ImportantDates.FirstOrDefault(x => x.Kind == ContactDateKind.Birthday);

                var myd = $"{date?.Day}/{date?.Month}/{date?.Year}";
                var teste = date?.ToString(); 


                phoneContacts.Add(new PhoneContact(item.DisplayName, phones, emails, null));
                i++;
            }

            return phoneContacts;
        }
    }
}
