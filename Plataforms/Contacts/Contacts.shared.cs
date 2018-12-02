using System.Collections.Generic;

namespace Plataforms
{
    public static partial class Contacts
    {
        public static IEnumerable<PhoneContact> GetContacts() => PlataformGetContacts();
    }
}
