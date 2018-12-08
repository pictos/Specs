using Android.App;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plataforms
{
    static partial class Contacts
    {
        public static Activity MyContext { get; set; }
        static void Getall()
        {
            string[] projection =
            {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Phone.Number,
                ContactsContract.Contacts.InterfaceConsts.PhotoId,
                ContactsContract.CommonDataKinds.Email.Address
            };
            var phoneNumber = new List<string>();
            var emails = new List<string>();
            var contacts = new List<PhoneContact>();

            var context = MyContext.ContentResolver;
            var cur = context.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, projection, null, null);

            if (cur.Count > 0)
            {
                while (cur.MoveToNext())
                {
                    var id = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id));
                    var name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                    var image = cur.GetString(cur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.PhotoUri));

                    if (int.Parse(ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber) > 0)
                    {
                        var pCur = context.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null,
                            ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

                        while (pCur.MoveToNext())
                        {
                            var phone = pCur.GetString(pCur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));
                            phoneNumber.Add($"Numero: {phone}");
                        }

                        pCur.Close();
                    }

                    var eCur = context.Query(ContactsContract.CommonDataKinds.Email.ContentUri, null,
                        ContactsContract.CommonDataKinds.Email.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

                    while (eCur.MoveToNext())
                    {
                        var email = eCur.GetString(eCur.GetColumnIndex(ContactsContract.CommonDataKinds.Email.Address));
                        emails.Add(email);
                    }

                    eCur.Close();

                    contacts.Add(new PhoneContact(name, phoneNumber, emails));
                }
            }
        }

        static void PlataformGetContacts(int ncontact)
        {
            try
            {
                Teste();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            //var contacts = new List<PhoneContact>();

            //var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;

            //string[] projection =
            //{
            //    ContactsContract.Contacts.InterfaceConsts.Id,
            //    ContactsContract.Contacts.InterfaceConsts.DisplayName,
            //    ContactsContract.CommonDataKinds.Phone.Number,
            //    ContactsContract.Contacts.InterfaceConsts.PhotoId,
            //    ContactsContract.CommonDataKinds.Email.Address
            //};



            //if (Looper.MyLooper() is null)
            //    Looper.Prepare();


            //var loader = new CursorLoader(Application.Context, uri, projection, null, null, null);
            //var cursor = (ICursor)loader.LoadInBackground();
            //if (cursor.MoveToFirst())
            //{
            //    do
            //    {
            //        var contactId = cursor.GetLong(cursor.GetColumnIndex(projection[0]));
            //        var name = cursor.GetString(cursor.GetColumnIndex(projection[1]));
            //        var phone = cursor.GetString(cursor.GetColumnIndex(projection[2]));
            //        var email = cursor.GetString(cursor.GetColumnIndex(projection[4]));
            //        var photo = cursor.GetString(cursor.GetColumnIndex(projection[3]));

            //        contacts.Add(new PhoneContact(name + " " + contactId.ToString(), new[] { phone }, new[] { email }));

            //    } while (cursor.MoveToNext());
            //}

            //    return Task.FromResult(contacts.AsEnumerable());
        }

        static void Teste()
        {
            var phoneContacts = new List<PhoneContact>();
            var uri = ContactsContract.Contacts.ContentUri;
            var context = Android.App.Application.Context.ContentResolver;
            var phoneNumber = new List<string>();
            var emails = new List<string>();
            var projection = new[]
            {
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Email.Address,
                ContactsContract.CommonDataKinds.Phone.Number
            };
            var cur = Android.App.Application.Context.ContentResolver.Query
                 (uri, null, null, null, null);

            if (cur is null | cur.Count == 0)
                return;

            while (cur.MoveToNext())
            {
                if (cur.Count > 0)
                {
                    while (cur.MoveToNext())
                    {
                        var id = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id));
                        var name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                        var image = cur.GetString(cur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.PhotoUri));

                        if (ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber.Length > 0)
                        {
                            var pCur = context.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null,
                                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

                            while (pCur.MoveToNext())
                            {
                                var phone = pCur.GetString(pCur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));
                                phoneNumber.Add($"Numero: {phone}");
                            }

                            pCur.Close();
                        }

                        var eCur = context.Query(ContactsContract.CommonDataKinds.Email.ContentUri, null,
                            ContactsContract.CommonDataKinds.Email.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

                        while (eCur.MoveToNext())
                        {
                            var email = eCur.GetString(eCur.GetColumnIndex(ContactsContract.CommonDataKinds.Email.Address));
                            emails.Add(email);
                        }

                        eCur.Close();

                        phoneContacts.Add(new PhoneContact(name, phoneNumber, emails));
                        emails.Clear();
                        phoneNumber.Clear();
                    }
                }
            }

            var batata = phoneContacts[5].Emails.FirstOrDefault();
            cur.Close();
        }
    }
}
