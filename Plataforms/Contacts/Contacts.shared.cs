using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Plataforms
{
    public static partial class Contacts
    {
        public static event EventHandler<CallBackArgs> CallBack;

        internal static ManualResetEvent Manualreset = new ManualResetEvent(true);

        //internal static void OnChanged(ManualResetEvent mre) =>
        //    OnChanged(new CallBackArgs(mre));

        //internal static void OnChanged(CallBackArgs e)
        //{
        //    CallBack?.Invoke(null,)
        //}

        public static void GetContacts(int ncontact) => PlataformGetContacts(ncontact);
    }

    public class CallBackArgs : EventArgs
    {
        public ManualResetEvent Mre { get; }

        public IEnumerable<PhoneContact> Phones { get; }

        public CallBackArgs(ManualResetEvent mre, IEnumerable<PhoneContact> phones)
        {
            Mre = mre;
            Phones = phones;
        }
    }
}
