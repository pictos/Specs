using Android.App;
using Android.Provider;
using System;
using System.Collections.Generic;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace Plataforms
{
    static partial class Contacts
    {
        public static Activity MyContext { get; set; }

        static void PlataformGetContacts(int ncontact)
        {
            try
            {
                //Teste();
                Final();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        #region Teste
        //static void Teste()
        //{
        //    var phoneContacts = new List<PhoneContact>();
        //    var uri = ContactsContract.Contacts.ContentUri;
        //    var context = Android.App.Application.Context.ContentResolver;
        //    var phoneNumber = new List<string>();
        //    var emails = new List<string>();
        //    var projection = new[]
        //    {
        //        ContactsContract.Contacts.InterfaceConsts.DisplayName,
        //        Email.Address,
        //        Phone.Number,
        //        StructuredPostal.Street
        //    };
        //    var cur = Android.App.Application.Context.ContentResolver.Query
        //         (uri, null, null, null, null);

        //    if (cur is null | cur.Count == 0)
        //        return;

        //    while (cur.MoveToNext())
        //    {
        //        if (cur.Count > 0)
        //        {
        //            while (cur.MoveToNext())
        //            {
        //                var id = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id));
        //                var name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
        //                var image = cur.GetString(cur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.PhotoUri));

        //                #region PhoneNumber
        //                if (ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber.Length > 0)
        //                {
        //                    var pCur = context.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null,
        //                        ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

        //                    while (pCur.MoveToNext())
        //                    {
        //                        var phone = pCur.GetString(pCur.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));
        //                        phoneNumber.Add($"Numero: {phone}");
        //                    }

        //                    pCur.Close();
        //                }
        //                #endregion

        //                #region Email
        //                var eCur = context.Query(ContactsContract.CommonDataKinds.Email.ContentUri, null,
        //                                ContactsContract.CommonDataKinds.Email.InterfaceConsts.ContactId + " = ?", new string[] { id }, null);

        //                while (eCur.MoveToNext())
        //                {
        //                    var email = eCur.GetString(eCur.GetColumnIndex(ContactsContract.CommonDataKinds.Email.Address));
        //                    emails.Add(email);
        //                }

        //                eCur.Close();
        //                #endregion

        //                #region BirthDay
        //                var projectionB = new[]
        //                             {
        //                    ContactsContract.Contacts.InterfaceConsts.Id, ContactsContract.CommonDataKinds.Event.StartDate
        //                };

        //                var query = ContactsContract.CommonDataKinds.CommonColumns.Type + " = " + 3
        //               + " AND " + ContactsContract.CommonDataKinds.Event.InterfaceConsts.ContactId + " = ?";

        //                var bCur = context.Query(ContactsContract.Data.ContentUri, projectionB, query, new string[] { id }, null);

        //                string e = null;
        //                while (bCur.MoveToNext())
        //                {
        //                    var b = bCur.GetString(bCur.GetColumnIndex(projectionB[1]));
        //                    DateTime.TryParse(b, out DateTime d);
        //                    e = d.ToShortDateString().Contains("1/1/0001") ? string.Empty
        //                        : d.ToShortDateString();
        //                }

        //                bCur.Close();
        //                #endregion

        //                #region StreetAddress

        //                var projectionS = new[] { StructuredPostal.Street, StructuredPostal.City, StructuredPostal.Postcode };
        //                var queryS = ContactsContract.Data.InterfaceConsts.ContactId;

        //                var sd = context.Query(ContactsContract.Data.ContentUri,
        //                    projectionS, queryS, new string[] { id, StructuredPostal.ContentItemType }, null);

        //                var street = sd.GetString(sd.GetColumnIndex(projection[0]));
        //                var city = sd.GetString(sd.GetColumnIndex(projection[1]));
        //                var postCode = sd.GetString(sd.GetColumnIndex(projection[2]));

        //                sd.Close();

        //                #endregion

        //                phoneContacts.Add(new PhoneContact(name, phoneNumber, emails, e));
        //                emails.Clear();
        //                phoneNumber.Clear();

        //            }
        //        }
        //    }

        //    var batata = phoneContacts[5].Emails.FirstOrDefault();
        //    cur.Close();
        //} 
        #endregion

        static void Final()
        {
            try
            {
                var phoneContacts = new List<PhoneContact>();
                var uri = ContactsContract.Contacts.ContentUri;
                var context = Application.Context.ContentResolver;
                var phoneNumbers = new List<string>();
                var emails = new List<string>();

                var cur = context.Query(uri, null, null, null, null);

                if (cur is null | cur.Count == 0) return;

                while (cur.MoveToNext())
                {
                    var id = cur.GetString(cur.GetColumnIndexOrThrow(ContactsContract.Contacts.InterfaceConsts.Id));
                    var name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));

                    #region PhoneNumber
                    var idQ = new string[] { id };
                    if (ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber.Length > 0)
                    {
                        var pCur = context.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null, Phone.InterfaceConsts.ContactId + " = ?", idQ, null);
                        while (pCur.MoveToNext())
                        {
                            var phone = pCur.GetString(pCur.GetColumnIndex(Phone.Number));
                            phoneNumbers.Add(phone);
                        }
                        pCur.Close();
                    }
                    #endregion

                    #region Email

                    var eCur = context.Query(Email.ContentUri, null, Email.InterfaceConsts.ContactId + " = ?", idQ, null);

                    while (eCur.MoveToNext())
                    {
                        var email = eCur.GetString(eCur.GetColumnIndex(Email.Address));
                        emails.Add(email);
                    }

                    eCur.Close();

                    #endregion

                    #region BirthDay
                    string b = string.Empty;
                    if (name.Contains("EuMesmo"))
                    {
                        var query = CommonColumns.Type + " = " + 3
                      + " AND " + Event.InterfaceConsts.ContactId + " = ?";

                        var bCur = context.Query(ContactsContract.Data.ContentUri, null, query, idQ, null);
                        while (bCur.MoveToNext())
                        {
                            b = bCur.GetString(bCur.GetColumnIndex(Event.StartDate));
                            //  bool t = false;
                        }
                        bCur.Close();
                    }
                    #endregion

                    #region Address
                    
                    if (name.Contains("EuMesmo"))
                    {
                        var projectionS = new[] { StructuredPostal.Street, StructuredPostal.City, StructuredPostal.Postcode };
                        var aCur = context.Query(ContactsContract.Data.ContentUri, projectionS, ContactsContract.Data.InterfaceConsts.ContactId + " = ?", idQ, null);
                        while (aCur.MoveToNext())
                        {
                            var street = aCur.GetString(aCur.GetColumnIndex(StructuredPostal.Street));
                            var city = aCur.GetString(aCur.GetColumnIndex(StructuredPostal.City));
                            var postCode = aCur.GetString(aCur.GetColumnIndex(StructuredPostal.Postcode));
                        }

                        aCur.Close();
                    }

                    #endregion

                    phoneContacts.Add(new PhoneContact(name, phoneNumbers, emails, b));
                    emails.Clear();
                    phoneNumbers.Clear();
                }
                cur.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
