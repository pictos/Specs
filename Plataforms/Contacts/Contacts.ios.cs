using Contacts;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plataforms
{
    static partial class Contacts
    {
        static void PlataformGetContacts(int ncontact)
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

                var numbers = item.PhoneNumbers.Select(x => x.Value.StringValue);
                var emails = item.EmailAddresses.Select(x => x.Value.ToString());
                var bd = item.Birthday.Date.ToString();
                contacts.Add(new PhoneContact(
                    item.GivenName + item.FamilyName,
                    numbers,
                    emails,
                    bd));

            }

          //  return Task.FromResult(contacts.AsEnumerable());
        }
    }
}
