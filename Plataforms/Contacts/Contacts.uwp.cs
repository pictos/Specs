using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Contacts;

namespace Plataforms
{
    static partial class Contacts
    {
        static IEnumerable<PhoneContact> PlataformGetContacts()
        {

            var contactStore = ContactManager.RequestStoreAsync().AsTask().GetAwaiter().GetResult();
            var contacts = contactStore.FindContactsAsync().AsTask().GetAwaiter().GetResult();
            if (contacts is null) return null;

            var phoneContacts = new List<PhoneContact>();
            foreach (var item in contacts)
            {                
                //if (item.IsMe)
                //    break;

                var phone = (item.Phones.Count > 0) ? item.Phones[0].Number : " ";
                var email = (item.Emails.Count > 0) ? item.Emails[0].Address : " ";

                phoneContacts.Add(new PhoneContact(item.DisplayName, phone , email));
            }

            return phoneContacts;
        }
    }
}
