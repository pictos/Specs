using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace Plataforms
{
    static partial class Contacts
    {
        static async void PlataformGetContacts(int ncontact)
        {
            var phoneContacts = new List<PhoneContact>();

            var contactStore = await ContactManager.RequestStoreAsync();
            //var contacts = contactStore.FindContactsAsync().AsTask().GetAwaiter().GetResult();
            var contacts = await contactStore.FindContactsAsync();

            var i = 0;

            foreach (var item in contacts)
            {
                Manualreset.WaitOne();


                //if (ncontact == i)
                //{
                //    Manualreset.Reset();
                //    CallBack?.Invoke(null, new CallBackArgs(Manualreset, phoneContacts));
                //}

                var phones = item.Phones.Select(p => p.Number);
                var emails = item.Emails.Select(e => e.Address);
                var address = item.Addresses.Select(a => a.StreetAddress);
                var name = item.FirstName + item.MiddleName + item.LastName;
                var date = item.ImportantDates.FirstOrDefault(x => x.Kind == ContactDateKind.Birthday);
              


                if (name.Contains("gostosão",StringComparison.OrdinalIgnoreCase))
                {
                    var myd = $"{date.Day}/{date.Month}/{date.Year}";
                    var teste = date.ToString();
                    foreach (var se in item.ImportantDates)
                    {
                        var d = se;
                    }
                    
                }
                


                phoneContacts.Add(new PhoneContact(item.DisplayName, phones, emails,null));
                i++;
            }

            //contacts.ContinueWith(result =>
            //{
            //    if (!(contacts is null))
            //    {
            //        var i = 0;

            //        foreach (var item in result.GetAwaiter().GetResult())
            //        {
            //            Manualreset.WaitOne();


            //            if (ncontact == i)
            //            {
            //                Manualreset.Reset();
            //                CallBack?.Invoke(null, new CallBackArgs(Manualreset, phoneContacts));
            //            }

            //            var phones = item.Phones.Select(p => p.Number);
            //            var emails = item.Emails.Select(e => e.Address);
            //            var address = item.


            //            phoneContacts.Add(new PhoneContact(item.DisplayName, phones, emails));
            //            i++;
            //        }
            //    }
            //});




        }
    }
}
