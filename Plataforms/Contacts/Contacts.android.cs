using Android.App;
using Android.Provider;
using System;
using System.Collections.Generic;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace Plataforms
{
    static partial class Contacts
    {
        static void PlataformGetContacts(int pageSize)
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
