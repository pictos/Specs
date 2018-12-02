using Contacts;
using Foundation;
using System.Collections.Generic;

namespace Plataforms
{
    static partial class Contacts
    {
        static IEnumerable<PhoneContact> PlataformGetContacts()
        {
            var keysToFetch = new[] { CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.PhoneNumbers, CNContactKey.EmailAddresses };

            var contactList = new List<CNContact>();

            using (var store = new CNContactStore())
            {
                var request = new CNContactFetchRequest(keysToFetch);
                store.EnumerateContacts(request, out NSError error, new CNContactStoreListContactsHandler(
                    (CNContact contact, ref bool stop) => contactList.Add(contact)));
            }
            var contacts = new List<PhoneContact>();

            foreach (var item in contactList)
            {
                var numbers = item.PhoneNumbers;
                if(!(numbers is null))
                {
                    foreach (var i in numbers)
                    {
                        contacts.Add(new PhoneContact(
                            item.GivenName + item.FamilyName, 
                            i.Value.StringValue,
                            item.EmailAddresses[0].Value));
                    }
                }
            }

            return contacts;
        }
    }
}
