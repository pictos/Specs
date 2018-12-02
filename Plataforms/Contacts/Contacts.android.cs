using Android.Provider;
using System;
using System.Collections.Generic;

namespace Plataforms
{
    static partial class Contacts
    {
        static IEnumerable<PhoneContact> PlataformGetContacts()
        {
            var phoneContacts = new List<PhoneContact>();
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            var projection = new[]
            {
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Phone.Number,
                ContactsContract.CommonDataKinds.Email.Address
            };
            using (var phones = Android.App.Application.Context.ContentResolver.Query
                (uri, projection, null, null, null))
            {
                if (phones is null | phones.Count == 0)
                    return null;
               
                while (phones.MoveToNext())
                {
                    try
                    {
                        var name = phones.GetString(phones.GetColumnIndex(projection[0]));
                        var number = phones.GetString(phones.GetColumnIndex(projection[1]));
                        var email = phones.GetString(phones.GetColumnIndex(projection[2]));


                        phoneContacts.Add(new PhoneContact(name, number, email));
                    }
                    catch (Exception) { }

                }
                    phones.Close();
            }

            return phoneContacts;
        }
    }
}
