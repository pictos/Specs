using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
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

            string[] projection =
            {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Phone.Number,
                ContactsContract.Contacts.InterfaceConsts.PhotoId,
                ContactsContract.CommonDataKinds.Email.Address
            };

            if (Looper.MyLooper() is null)            
                Looper.Prepare();
            

            var loader = new CursorLoader(Application.Context, uri, projection, null, null, null);
            var cursor = (ICursor)loader.LoadInBackground();
            if (cursor.MoveToFirst())
            {
                do
                {
                    var contactId = cursor.GetLong(cursor.GetColumnIndex(projection[0]));
                    var name = cursor.GetString(cursor.GetColumnIndex(projection[1]));
                    var phone = cursor.GetString(cursor.GetColumnIndex(projection[2]));
                    var email = cursor.GetString(cursor.GetColumnIndex(projection[4]));
                    var photo = cursor.GetString(cursor.GetColumnIndex(projection[3]));

                    phoneContacts.Add(new PhoneContact(name+" "+contactId.ToString(), new[] { phone }, new[] { email }));

                } while (cursor.MoveToNext());
            }

            return phoneContacts;
        }

        //static void Teste()
        //{
        //    var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
        //    var projection = new[]
        //    {
        //        ContactsContract.Contacts.InterfaceConsts.DisplayName,
        //        ContactsContract.CommonDataKinds.Email.Address,
        //        ContactsContract.CommonDataKinds.Phone.Number
        //    };
        //    using (var phones = Android.App.Application.Context.ContentResolver.Query
        //        (uri, projection, null, null, null))
        //    {
        //        if (phones is null | phones.Count == 0)
        //            return null;

        //        while (phones.MoveToNext())
        //        {
        //            try
        //            {

        //                var name = phones.GetString(phones.GetColumnIndex(projection[0]));
        //                var number = phones.GetString(phones.GetColumnIndex(projection[1]));
        //                var email = phones.GetString(phones.GetColumnIndex(projection[2]));

        //                var _number = new[] { number };
        //                var _email = new[] { email };

        //                phoneContacts.Add(new PhoneContact(name, _number, _email));
        //            }
        //            catch (Exception) { }

        //        }
        //        phones.Close();
        //    }
        //}
    }
}
